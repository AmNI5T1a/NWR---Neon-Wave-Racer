using System;
using UnityEngine;

namespace NWR.PlayingMode
{
    public class Road : MonoBehaviour
    {
        public static event Action OnMoveLastPlacedRoad;
        private void OnTriggerEnter(Collider enteredCollider)
        {
            if (enteredCollider.tag == "Player")
            {
                OnMoveLastPlacedRoad?.Invoke();
            }
        }
    }
}
