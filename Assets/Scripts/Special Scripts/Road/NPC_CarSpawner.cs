using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NWR.PlayingMode
{
    public class NPC_CarSpawner : MonoBehaviour
    {
        public static NPC_CarSpawner Instance { get; private set; }

        [Header("Settings:")]

        [Header("Info box:")]
        [SerializeField] private List<LockedZonesFromSpawnNPC> _zones = new List<LockedZonesFromSpawnNPC>();

        [Serializable]
        private class LockedZonesFromSpawnNPC
        {
            [SerializeField] private GameObject objectThatLockingZone;
            [SerializeField] private float fromPreventingToSpawnNPC;
            [SerializeField] private float toPreventingToSpawnNPC;

            public LockedZonesFromSpawnNPC(ref GameObject carGameObject, float from, float to)
            {
                this.objectThatLockingZone = carGameObject;
                this.fromPreventingToSpawnNPC = from;
                this.toPreventingToSpawnNPC = to;
            }

            public GameObject GetGameObject() => objectThatLockingZone;

            // ! Important
            // TODO: convert with 2 methods in 1
            public void UpdateFrontLockBoundary(float from) => fromPreventingToSpawnNPC = from;
            public void UpdateRearLockBoundary(float to) => toPreventingToSpawnNPC = to;
            public void GetFromAndToBoundaries(out float from, out float to)
            {
                from = fromPreventingToSpawnNPC;
                to = toPreventingToSpawnNPC;
            }
        }



        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this.gameObject);
        }

        private void Update()
        {
            UpdateLockedZonesPosition();
        }

        private void UpdateLockedZonesPosition()
        {
            if (_zones.Count == 0)
                return;

            foreach (LockedZonesFromSpawnNPC zone in _zones)
            {
                float newFromBoundary;
                float newToBoundary;

                zone.GetGameObject().GetComponent<NPC_Settings>().GetBoundaries(out newFromBoundary, out newToBoundary);

                zone.UpdateFrontLockBoundary(newFromBoundary);
                zone.UpdateRearLockBoundary(newToBoundary);
            }

            // * Shows debug info for each zone
            foreach (LockedZonesFromSpawnNPC zone in _zones)
            {
                float fromBoundaryForThisZone;
                float toBoundaryForThisZone;
                zone.GetFromAndToBoundaries(out fromBoundaryForThisZone, out toBoundaryForThisZone);
                Debug.Log("Object name: " + zone.GetGameObject().name + "have params: " + fromBoundaryForThisZone + " " + toBoundaryForThisZone);
            }
        }

        public void AddCarThatCollidingWithSpawnZones(GameObject car)
        {
            float fromBoundary;
            float toBoundary;

            car.GetComponent<NPC_Settings>().GetBoundaries(out fromBoundary, out toBoundary);
            _zones.Add(new LockedZonesFromSpawnNPC(ref car, fromBoundary, toBoundary));
        }

        public void RemoveCarThatCollidingWithSpawnZones(GameObject car)
        {
            foreach (LockedZonesFromSpawnNPC zone in _zones)
            {
                if (zone.GetGameObject() == car)
                    _zones.Remove(zone);
            }
        }

        public bool CheckIfLockedZonesContainsGameObject(GameObject car)
        {
            foreach (LockedZonesFromSpawnNPC zone in _zones)
                if (zone.GetGameObject() == car) return true;

            return false;
        }
    }
}