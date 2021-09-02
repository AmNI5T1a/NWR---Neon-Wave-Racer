using UnityEngine;

public class BOXCAST_CAR_RAY : MonoBehaviour
{

    [Header("Stats:")]
    [SerializeField, Range(0, 1000)] private float _raycastLength;
    [SerializeField] private Vector3 _halfExtents;
    [SerializeField] private float _npcBackSideBoxCastSize;


    [Header("Info box:")]
    [ReadOnly, SerializeField] private bool m_HitDetect;


    private void Start()
    {
        if (_npcBackSideBoxCastSize <= 0)
            _npcBackSideBoxCastSize = 0.2f;
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
        RaycastHit hit;
        bool isHit = Physics.BoxCast(this.gameObject.transform.position, _halfExtents / 2, this.gameObject.transform.forward, out hit, this.gameObject.transform.rotation, _raycastLength);

        if (isHit)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, transform.forward * hit.distance);
            Gizmos.DrawCube(this.transform.position + transform.forward * hit.distance, _halfExtents);

            Gizmos.color = Color.black;
            Gizmos.DrawWireCube(hit.transform.gameObject.GetComponent<BoxCollider>().bounds.center, hit.transform.gameObject.GetComponent<BoxCollider>().size);

            Gizmos.color = Color.cyan;
            Gizmos.DrawCube(new Vector3(hit.transform.gameObject.GetComponent<BoxCollider>().bounds.center.x,
                                        hit.transform.gameObject.GetComponent<BoxCollider>().bounds.center.y,
                                        hit.transform.gameObject.GetComponent<BoxCollider>().bounds.center.z - (hit.transform.gameObject.GetComponent<BoxCollider>().bounds.size.z / 2)),
                            new Vector3(hit.transform.gameObject.GetComponent<BoxCollider>().size.x,
                                        hit.transform.gameObject.GetComponent<BoxCollider>().size.y,
                                        _npcBackSideBoxCastSize));
        }
        else
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, transform.forward * _raycastLength);
            Gizmos.DrawCube(this.transform.position + transform.forward * _raycastLength, _halfExtents);

        }
    }
}
