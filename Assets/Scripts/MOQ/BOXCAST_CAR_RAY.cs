using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NWR.PlayingMode
{
    public class BOXCAST_CAR_RAY : MonoBehaviour
    {
        [SerializeField] private float _rayLength;
        [SerializeField] private Vector3 _triggerZoneSize;
        [SerializeField] private LayerMask _layerMaskForTrigger;

        [Header("Stats:")]
        [SerializeField] private Vector3 possibleSpawnPosition = new Vector3();
        private void OnTriggerEnter(Collider enteredCollider)
        {
            if (enteredCollider.gameObject.tag == "NPC")
                Destroy(enteredCollider.gameObject);
        }

        private void OnDrawGizmos()
        {
            RaycastHit hit;
            bool isHit = false;
            isHit = Physics.BoxCast(this.transform.position, _triggerZoneSize / 2, this.transform.forward, out hit, Quaternion.identity, _rayLength, _layerMaskForTrigger);

            if (isHit)
            {
                possibleSpawnPosition = this.transform.position - new Vector3(0f, 0f, hit.distance);

                Gizmos.color = Color.red;
                Gizmos.DrawWireCube(this.transform.position - new Vector3(0f, 0f, hit.distance), _triggerZoneSize);
                Gizmos.DrawRay(this.transform.position, this.transform.forward - new Vector3(0f, 0f, hit.distance));

                if (hit.transform.gameObject.tag == "Car")
                    hit.transform.gameObject.GetComponent<I_NPC_CarDestroyer>().DestroyGameObject();
            }
            else
            {
                possibleSpawnPosition = this.transform.position - new Vector3(0f, 0f, _rayLength);

                Gizmos.color = Color.green;
                Gizmos.DrawWireCube(this.transform.position - new Vector3(0f, 0f, _rayLength), _triggerZoneSize);
                Gizmos.DrawRay(this.transform.position, this.transform.forward - new Vector3(0f, 0f, _rayLength));
            }
        }

        public Vector3 GetPossibleSpawnPosition() => possibleSpawnPosition;
    }
}