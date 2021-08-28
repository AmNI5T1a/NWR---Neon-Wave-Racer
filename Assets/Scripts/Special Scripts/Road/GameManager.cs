using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NWR.PlayingMode
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private float[] _xPositionsForSpawnNPCCars;

        [Header("Stats:")]
        [SerializeField] private ushort _minNCPCarsOnScene;
        [SerializeField] private ushort _maxNCPCarsOnScene;

        [Space(10)]

        [SerializeField] private float _minDelayBetweenSpawnNPCCars;
        [SerializeField] private float _maxDelayBetweenSpawnNPCCars;


        [Header("Info box:")]
        [ReadOnly, SerializeField] private byte _currentNumberOfNPCCarsOnScene;
        [ReadOnly, SerializeField] private List<GameObject> _listOfSpawnedNPCCars = new List<GameObject>();

        private void Start()
        {
            // TODO: min speed for player car

        }

        private IEnumerator OneDirectionOfSpawningCars()
        {
            yield return null;
        }
    }
}
