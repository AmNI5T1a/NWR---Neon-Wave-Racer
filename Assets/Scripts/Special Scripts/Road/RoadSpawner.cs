using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace NWR.PlayingMode
{
    public class RoadSpawner : MonoBehaviour
    {
        public static RoadSpawner Instance;
        [SerializeField] private List<GameObject> listOfRoadsGameObjects;
        [SerializeField] private float roadSize;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this.gameObject);

            Road.OnMoveLastPlacedRoad += MoveRoad;
        }

        public void MoveRoad()
        {
            float roadPosition = listOfRoadsGameObjects.Min(x => x.transform.position.z);
            GameObject roadToMove = listOfRoadsGameObjects.First(x => x.transform.position.z == roadPosition);
            float roadPositionToMove = listOfRoadsGameObjects.Max(x => x.transform.position.z);
            GameObject whereToMove = listOfRoadsGameObjects.First(x => x.transform.position.z == roadPositionToMove);
            roadToMove.transform.position = new Vector3(roadToMove.transform.position.x, roadToMove.transform.position.y, whereToMove.transform.position.z + roadSize);
        }
    }
}
