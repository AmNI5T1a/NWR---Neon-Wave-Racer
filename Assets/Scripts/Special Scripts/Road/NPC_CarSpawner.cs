using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NWR.PlayingMode
{
    public class NPC_CarSpawner : MonoBehaviour
    {
        [Header("References:")]
        [SerializeField] private List<GameObject> _listOfSpawnZonesGameObjects;


        private void LateUpdate()
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                SpawnNPC_CarGameObject();
            }
        }


        private void SpawnNPC_CarGameObject()
        {
            System.Random rnmGenerator = new System.Random();
            GameObject rnmlyChoosenSideToSpawn = _listOfSpawnZonesGameObjects[rnmGenerator.Next(0, _listOfSpawnZonesGameObjects.Count)];

            GameObject npc_Car = Instantiate(Resources.Load("NPC"), rnmlyChoosenSideToSpawn.GetComponent<BOXCAST_CAR_RAY>().GetPossibleSpawnPosition(), Quaternion.identity) as GameObject;
        }
    }
}