using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Settings : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _frontBlockedZoneRangeFromSpawningNPC;
    [SerializeField] private float _rearBlockedZoneRangeFromSpawningNPC;

    [Header("Info box:")]
    [ReadOnly, SerializeField] private float _front_Z_LockedFromSpawnZone;
    [ReadOnly, SerializeField] private float _rear_Z_LockedFromSpawnZone;


    private void Update()
    {
        _front_Z_LockedFromSpawnZone = this.gameObject.GetComponent<BoxCollider>().bounds.center.z + _frontBlockedZoneRangeFromSpawningNPC;
        _rear_Z_LockedFromSpawnZone = this.gameObject.GetComponent<BoxCollider>().bounds.center.z - _rearBlockedZoneRangeFromSpawningNPC;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Bounds colliderBounds = this.gameObject.GetComponent<BoxCollider>().bounds;
        Gizmos.DrawCube(colliderBounds.center + new Vector3(0f, 0f, _frontBlockedZoneRangeFromSpawningNPC), new Vector3(colliderBounds.size.x, colliderBounds.size.y, 0f));
        Gizmos.DrawCube(colliderBounds.center + new Vector3(0f, 0f, -_rearBlockedZoneRangeFromSpawningNPC), new Vector3(colliderBounds.size.x, colliderBounds.size.y, 0f));

        Gizmos.DrawRay(colliderBounds.center + new Vector3((colliderBounds.size.x / 2), (colliderBounds.size.y / 2), _frontBlockedZoneRangeFromSpawningNPC), -transform.forward * (Vector3.Distance(colliderBounds.center + new Vector3(0f, 0f, _frontBlockedZoneRangeFromSpawningNPC), colliderBounds.center + new Vector3(0f, 0f, -_rearBlockedZoneRangeFromSpawningNPC))));
        Gizmos.DrawRay(colliderBounds.center + new Vector3(-(colliderBounds.size.x / 2), (colliderBounds.size.y / 2), _frontBlockedZoneRangeFromSpawningNPC), -transform.forward * (Vector3.Distance(colliderBounds.center + new Vector3(0f, 0f, _frontBlockedZoneRangeFromSpawningNPC), colliderBounds.center + new Vector3(0f, 0f, -_rearBlockedZoneRangeFromSpawningNPC))));
        Gizmos.DrawRay(colliderBounds.center + new Vector3((colliderBounds.size.x / 2), -(colliderBounds.size.y / 2), _frontBlockedZoneRangeFromSpawningNPC), -transform.forward * (Vector3.Distance(colliderBounds.center + new Vector3(0f, 0f, _frontBlockedZoneRangeFromSpawningNPC), colliderBounds.center + new Vector3(0f, 0f, -_rearBlockedZoneRangeFromSpawningNPC))));
        Gizmos.DrawRay(colliderBounds.center + new Vector3(-(colliderBounds.size.x / 2), -(colliderBounds.size.y / 2), _frontBlockedZoneRangeFromSpawningNPC), -transform.forward * (Vector3.Distance(colliderBounds.center + new Vector3(0f, 0f, _frontBlockedZoneRangeFromSpawningNPC), colliderBounds.center + new Vector3(0f, 0f, -_rearBlockedZoneRangeFromSpawningNPC))));
    }

    public void GetBoundaries(out float front, out float rear)
    {
        front = _front_Z_LockedFromSpawnZone;
        rear = _rear_Z_LockedFromSpawnZone;
    }
}
