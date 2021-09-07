using System.Collections.Generic;
using UnityEngine;

namespace NWR.PlayingMode
{
    public class BOXCAST_CAR_RAY : MonoBehaviour
    {
        private void OnTriggerEnter(Collider enteredCollider)
        {
            if (enteredCollider.gameObject.layer == 14)
            {
                if (!NPC_CarSpawner.Instance.CheckIfLockedZonesContainsGameObject(enteredCollider.gameObject))
                {
                    NPC_CarSpawner.Instance.AddCarThatCollidingWithSpawnZones(enteredCollider.gameObject);
                    Debug.Log("! New car in list of cars that colliding with spawn zones (name of object: " + enteredCollider.gameObject.name + ")");
                }
            }
        }

        private void OnTriggerExit(Collider leavedCollider)
        {
            if (leavedCollider.gameObject.layer == 14)
            {
                if (NPC_CarSpawner.Instance.CheckIfLockedZonesContainsGameObject(leavedCollider.gameObject))
                {
                    NPC_CarSpawner.Instance.RemoveCarThatCollidingWithSpawnZones(leavedCollider.gameObject);
                    Debug.Log("! Removed car from the list of cars which colliding with spawn zones (name of object: " + leavedCollider.gameObject.name + ")");
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(this.gameObject.GetComponent<BoxCollider>().bounds.center, this.gameObject.GetComponent<BoxCollider>().size);
        }
    }
}