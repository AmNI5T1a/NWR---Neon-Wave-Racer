using UnityEngine;

public class BOXCAST_CAR_RAY : MonoBehaviour
{

    [Header("Stats:")]
    [SerializeField, Range(0, 1000)] private float _raycastLength;
    [SerializeField] private Vector3 _halfExtents;
    [SerializeField] private float _NonSpawningAreaSize;
    [SerializeField] private float _NCPCarBackSideBoxCastSize;


    [Header("Info box:")]
    [ReadOnly, SerializeField] private bool m_HitDetect;


    private void Start()
    {

    }


    private void OnDrawGizmos()
    {
        RaycastHit hit;
        bool isHit = Physics.BoxCast(this.gameObject.transform.position, _halfExtents / 2, this.gameObject.transform.forward, out hit, this.gameObject.transform.rotation, _raycastLength);

        if (isHit)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, transform.forward * hit.distance);

            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(new Vector3(this.gameObject.transform.position.x, this.transform.position.y, hit.collider.bounds.center.z),
                                new Vector3(hit.transform.gameObject.GetComponent<BoxCollider>().size.x,
                                            hit.transform.gameObject.GetComponent<BoxCollider>().size.y,
                                            _NonSpawningAreaSize));

            Gizmos.DrawCube(new Vector3(this.gameObject.transform.position.x, this.transform.position.y, hit.collider.bounds.center.z) + new Vector3(0f, 0f, (float)(-(_NonSpawningAreaSize / 2))), new Vector3(hit.transform.gameObject.GetComponent<BoxCollider>().bounds.size.x, hit.transform.gameObject.GetComponent<BoxCollider>().bounds.size.y, _NCPCarBackSideBoxCastSize));

            Gizmos.color = Color.green;
            Gizmos.DrawRay(new Vector3(this.gameObject.transform.position.x, this.transform.position.y, hit.collider.bounds.center.z) + new Vector3(0f, 0f, (float)(-(_NonSpawningAreaSize / 2))), transform.forward * (_raycastLength - Vector3.Distance(hit.transform.gameObject.GetComponent<BoxCollider>().bounds.center + new Vector3(0f, 0f, (float)(-(_NonSpawningAreaSize / 2))), this.transform.position)));
            Gizmos.DrawWireCube(this.transform.position + transform.forward * _raycastLength, _halfExtents);

        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, transform.forward * _raycastLength);
            Gizmos.DrawWireCube(this.transform.position + transform.forward * _raycastLength, _halfExtents);

        }
    }
}
