using UnityEngine;

namespace NWR.Modules
{
    public class KeyboardInput : InputBaseState
    {
        public override void MonitorInput()
        {
            if (Input.GetKey(KeyCode.D))
            {
                VirtualInputManager.Instance.MoveRight = true;
            }
            else
            {
                VirtualInputManager.Instance.MoveRight = false;
            }

            if (Input.GetKey(KeyCode.A))
            {
                VirtualInputManager.Instance.MoveLeft = true;
            }
            else
            {
                VirtualInputManager.Instance.MoveLeft = false;
            }

            if (Input.GetKey(KeyCode.W))
            {
                VirtualInputManager.Instance.MoveForward = true;
            }
            else
            {
                VirtualInputManager.Instance.MoveForward = false;
            }

            if (Input.GetKey(KeyCode.S))
            {
                VirtualInputManager.Instance.MoveBack = true;
            }
            else
            {
                VirtualInputManager.Instance.MoveBack = false;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                VirtualInputManager.Instance.Brake = true;
            }
            else
            {
                VirtualInputManager.Instance.Brake = false;
            }

            if (Input.GetKey(KeyCode.C))
            {
                VirtualInputManager.Instance.C = true;
            }
            else
            {
                VirtualInputManager.Instance.C = false;
            }
        }

        public override void Start()
        {
            Debug.Log("Switched to Keyboard Input");
        }

        public override void Stop()
        {
            Debug.Log("Turning off Keyboard Input");
        }
    }
}