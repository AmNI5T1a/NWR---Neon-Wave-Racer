using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace NWR.Modules
{
    public class CarControlling : MonoBehaviour
    {
        [Header("References: ")]
        [SerializeField] private WheelColliders _wheelColliders;
        [Serializable]
        private class WheelColliders
        {
            public WheelCollider FrontLeftWheel;
            public WheelCollider FrontRightWheel;
            public WheelCollider RearLeftWheel;
            public WheelCollider RearRightWheel;

            public List<WheelCollider> GetFrontWheelColliders
            {
                get => new List<WheelCollider> { FrontLeftWheel, FrontRightWheel };
            }
            public List<WheelCollider> GetRearWheelCollider
            {
                get => new List<WheelCollider> { RearLeftWheel, RearRightWheel };
            }
            public List<WheelCollider> GetWheelColliders
            {
                get => new List<WheelCollider> { FrontLeftWheel, FrontRightWheel, RearLeftWheel, RearRightWheel };
            }
        }

        [SerializeField] private WheelTransforms _wheelTransforms;
        [Serializable]
        public class WheelTransforms
        {
            public Transform FrontLeftWheel;
            public Transform FrontRightWheel;
            public Transform RearLeftWheel;
            public Transform RearRightWheel;

            public List<Transform> GetFrontWheelTransforms
            {
                get => new List<Transform> { FrontLeftWheel, FrontRightWheel };
            }
            public List<Transform> GetRearWheelTransforms
            {
                get => new List<Transform> { RearLeftWheel, RearRightWheel };
            }
            public List<Transform> GetWheelTransforms
            {
                get => new List<Transform> { FrontLeftWheel, FrontRightWheel, RearLeftWheel, RearRightWheel };
            }
        }

        [HideInInspector] private Rigidbody _carRigidbody;

        [Header("Stats: ")]

        [SerializeField] private float _horizontalInputSteeringSpeed;
        [SerializeField] private float steeringSpeed;
        [SerializeField] private float motorTorque;
        [SerializeField] private float brakeTorque;
        [SerializeField] private float maxSpeed;
        [SerializeField] private float minSpeed;

        [SerializeField] private Gears _gearSystem;
        [Serializable]
        private class Gears
        {
            public float[] gears;

            public void ShiftGearUp(ref byte currentGear)
            {
                if (currentGear != gears.Count() - 1)
                {
                    currentGear++;
                }
            }

            public void ShiftGearDown(ref byte currentGear)
            {
                if (currentGear != 0)
                    currentGear--;
            }
        }
        [SerializeField] private float minRPM;
        [SerializeField] private float maxRPM;


        [Header("Info box: ")]
        [ReadOnly, SerializeField] private float _currentHorizontalInput;
        [ReadOnly, SerializeField] private float _currentVeritcalInput;

        [Space(10)]

        [ReadOnly, SerializeField] private float _currentSpeed;
        [ReadOnly, SerializeField] private byte _currentSpeedGear;
        [ReadOnly, SerializeField] private float _currentRPM;
        [ReadOnly, SerializeField] private float _shiftDownCooldownRemainingTime;
        [ReadOnly, SerializeField] private bool _shiftDownOnCooldown;

        private void Awake()
        {
            _carRigidbody = this.gameObject.GetComponent<Rigidbody>();
        }
        private void Start()
        {
            _currentSpeedGear = 0;

            _shiftDownOnCooldown = false;
        }


        private void FixedUpdate()
        {
            // * Calculate original speed of the car
            _currentSpeed = _carRigidbody.velocity.magnitude * 2.7f;

            SpeedController();
            CarSteering();
            CarMovement();
            GearsSystem();

            UpdatePositionForEachWheel();
        }

        private void SpeedController()
        {
            if (_carRigidbody.velocity.magnitude > maxSpeed)
            {
                _carRigidbody.velocity = _carRigidbody.velocity.normalized * maxSpeed;
            }

            if (_carRigidbody.velocity.magnitude <= minSpeed)
            {
                _carRigidbody.velocity = _carRigidbody.velocity.normalized * minSpeed;
            }
        }

        private void CarSteering()
        {
            if (VirtualInputManager.Instance.MoveLeft && VirtualInputManager.Instance.MoveRight)
            {
                return;
            }

            if (!VirtualInputManager.Instance.MoveLeft && !VirtualInputManager.Instance.MoveRight)
            {
                _currentHorizontalInput = Mathf.MoveTowards(_currentHorizontalInput, 0f, _horizontalInputSteeringSpeed);

                this.transform.rotation = Quaternion.AngleAxis(_currentHorizontalInput * steeringSpeed, Vector3.up);

                foreach (WheelCollider wheel in _wheelColliders.GetFrontWheelColliders)
                {
                    wheel.steerAngle = _currentHorizontalInput * steeringSpeed;
                }
            }

            if (VirtualInputManager.Instance.MoveLeft)
            {
                if (_currentHorizontalInput > -1f)
                {
                    _currentHorizontalInput -= _horizontalInputSteeringSpeed;

                    this.transform.rotation = Quaternion.AngleAxis(_currentHorizontalInput * steeringSpeed, Vector3.up);

                    foreach (WheelCollider wheel in _wheelColliders.GetFrontWheelColliders)
                        wheel.steerAngle = _currentHorizontalInput * steeringSpeed;
                }
            }

            if (VirtualInputManager.Instance.MoveRight)
            {
                if (_currentHorizontalInput < 1f)
                {
                    _currentHorizontalInput += _horizontalInputSteeringSpeed;

                    this.transform.rotation = Quaternion.AngleAxis(_currentHorizontalInput * steeringSpeed, Vector3.up);

                    foreach (WheelCollider wheel in _wheelColliders.GetFrontWheelColliders)
                        wheel.steerAngle = _currentHorizontalInput * steeringSpeed;
                }
            }
        }

        private void CarMovement()
        {

            if (VirtualInputManager.Instance.MoveForward && VirtualInputManager.Instance.Brake)
                return;

            if (VirtualInputManager.Instance.MoveForward && !VirtualInputManager.Instance.Brake)
            {
                foreach (WheelCollider wheel in _wheelColliders.GetWheelColliders)
                    wheel.motorTorque = motorTorque * _gearSystem.gears[_currentSpeedGear];
            }
            else
            {
                foreach (WheelCollider wheel in _wheelColliders.GetWheelColliders)
                    wheel.motorTorque = 0f;
            }

            if (VirtualInputManager.Instance.Brake && !VirtualInputManager.Instance.MoveForward)
            {
                foreach (WheelCollider wheel in _wheelColliders.GetWheelColliders)
                {
                    wheel.motorTorque = 0f;
                    wheel.brakeTorque = brakeTorque;
                }

            }
            else
            {
                foreach (WheelCollider wheel in _wheelColliders.GetWheelColliders)
                    wheel.brakeTorque = 0f;
            }
        }
        private void GearsSystem()
        {
            // ! NOT TESTED
            float frontLeftWheelRPM = Mathf.Abs((_wheelColliders.FrontLeftWheel.rpm) * _gearSystem.gears[_currentSpeedGear]);
            float frontRightWheelRPM = Mathf.Abs((_wheelColliders.FrontRightWheel.rpm) * _gearSystem.gears[_currentSpeedGear]);
            float rearLeftWheelRPM = Mathf.Abs((_wheelColliders.RearLeftWheel.rpm) * _gearSystem.gears[_currentSpeedGear]);
            float rearRightWheelRPM = Mathf.Abs((_wheelColliders.RearRightWheel.rpm) * _gearSystem.gears[_currentSpeedGear]);
            _currentRPM = (frontLeftWheelRPM + frontRightWheelRPM + rearLeftWheelRPM + rearRightWheelRPM) / 4;
            // !

            ///          
            /// Shift Up
            ///
            if (_currentRPM > maxRPM && VirtualInputManager.Instance.MoveForward)
            {
                _gearSystem.ShiftGearUp(ref _currentSpeedGear);
            }

            /// 
            /// Shift Down
            ///
            if (_currentRPM < minRPM && !_shiftDownOnCooldown)
            {
                _gearSystem.ShiftGearDown(ref _currentSpeedGear);
                _shiftDownCooldownRemainingTime = 1f;
                _shiftDownOnCooldown = true;
            }
            else if (_currentRPM < minRPM && _shiftDownOnCooldown)
            {
                _shiftDownCooldownRemainingTime -= Time.deltaTime;
                if (_shiftDownCooldownRemainingTime <= 0)
                {
                    _shiftDownOnCooldown = false;
                }
            }
        }

        private void UpdatePositionForEachWheel()
        {
            UpdateWheelsPose(_wheelColliders.FrontLeftWheel, _wheelTransforms.FrontLeftWheel);
            UpdateWheelsPose(_wheelColliders.FrontRightWheel, _wheelTransforms.FrontRightWheel);
            UpdateWheelsPose(_wheelColliders.RearLeftWheel, _wheelTransforms.RearLeftWheel);
            UpdateWheelsPose(_wheelColliders.RearRightWheel, _wheelTransforms.RearRightWheel);
        }

        private void UpdateWheelsPose(WheelCollider collider, Transform transform)
        {
            Vector3 CurrentPosition = transform.position;
            Quaternion CurrentRotation = transform.rotation;

            collider.GetWorldPose(out CurrentPosition, out CurrentRotation);

            transform.position = CurrentPosition;
            //transform.rotation = CurrentRotation;
            transform.rotation = new Quaternion(CurrentRotation.x, CurrentRotation.y, CurrentRotation.z, CurrentRotation.w);
        }
    }
}