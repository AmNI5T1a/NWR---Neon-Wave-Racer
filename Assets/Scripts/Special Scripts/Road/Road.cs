using UnityEngine;

namespace NWR.PlayingMode
{
    public class Road : MonoBehaviour
    {
        private void OnTriggerEnter(Collider enteredCollider)
        {
            if (enteredCollider.tag == "Car")
            {
                RoadSpawner.Instance.MoveRoad();
            }
        }
    }
}
