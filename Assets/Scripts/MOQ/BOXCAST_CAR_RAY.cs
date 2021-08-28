using UnityEngine;

public class BOXCAST_CAR_RAY : MonoBehaviour
{
    [Header("References: ")]
    [SerializeField] private Transform _carTransform;
    [SerializeField] private Rigidbody _carRigidbody;

    [Header("Stats:")]
    [SerializeField] private float _carCenterY;
    [SerializeField, Range(0, 1000f)] private float _raycastLength;
    [SerializeField] private Vector3 _halfExtents;
    [SerializeField] private Vector3 _direction;
    [SerializeField] private Quaternion _rotation;
    [SerializeField] private LayerMask _mask;


    [Header("Info box:")]
    [ReadOnly, SerializeField] private bool m_HitDetect;

    private void Awake()
    {
        _carTransform = this.gameObject.GetComponent<Transform>().transform;
        _carRigidbody = this.gameObject.GetComponent<Rigidbody>();
    }
    private void Start()
    {

    }

    private void Update()
    {
        Debug.Log("transform.position: " + transform.position.ToString());
        Debug.Log("transform.lossyScale/2: " + (transform.lossyScale / 2).ToString());
        Debug.Log("transform.forward: " + transform.forward.ToString());
        Debug.Log("transform.rotation: " + transform.rotation);
    }

    private void OnDrawGizmos()
    {

        // bool isHit = Physics.BoxCast(this.gameObject.transform.position,
        //                                 this.gameObject.transform.position,
        //                                 this.gameObject.transform.forward,
        //                                 out hit,
        //                                 this.gameObject.transform.rotation,
        //                                 maxDistance: _maxRaycastDistance
        //                                 );

        // Gizmos.color = Color.green;
        // Gizmos.DrawCube(this.gameObject.transform.position, _boxRaycastVector3Size);

        // if()

        // var sphereRay = Physics.SphereCast(origin, _boxRaycastVector3Size.x, direction, out hit);
        // Gizmos.color = Color.cyan;
        // Gizmos.DrawSphere(origin, _boxRaycastVector3Size.x);

        // if (sphereRay)
        // {
        //     Debug.Log(hit.transform.gameObject.name);
        // }
        // RaycastHit hit;

        // Vector3 origin = this.gameObject.transform.position + new Vector3(0, 0.6f, -1.6f);
        // Vector3 direction = this.gameObject.transform.TransformDirection(Vector3.forward);

        // Gizmos.color = Color.cyan;
        // Gizmos.DrawSphere(origin, _raycastRadius);

        // var sphereRay = Physics.SphereCast(origin, _raycastRadius, this.gameObject.transform.position * _raycastLength, out hit, maxDistance: _raycastLength);

        // if (sphereRay)
        // {
        //     Debug.Log(hit.transform.gameObject.name);
        // }

        RaycastHit hit;
        bool isHit = Physics.BoxCast(new Vector3(transform.position.x, _carCenterY, transform.position.z), _halfExtents, _direction, out hit, _rotation, _raycastLength, _mask);

        if (isHit)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, transform.forward * hit.distance);
            Gizmos.DrawWireCube(new Vector3(transform.position.x, _carCenterY, transform.position.z) + transform.forward * hit.distance, _halfExtents * 2);

            Gizmos.color = Color.black;
            Gizmos.DrawWireCube(hit.transform.gameObject.GetComponentInChildren<IGetCenterPosition>().GetCenterPosition(), hit.transform.gameObject.GetComponent<BoxCollider>().size);
        }
        else
        {
            // !!!!
            // TODO: change logic to draw cube on max distance
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, transform.forward * _raycastLength);
            Gizmos.DrawWireCube(new Vector3(transform.position.x, _carCenterY, transform.position.z) + transform.forward * _raycastLength, _halfExtents * 2);

        }
    }
}
