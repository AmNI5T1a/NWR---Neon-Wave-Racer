using System;
using System.Linq;
using System.Collections.Generic;
using NWR.Lobby;
using UnityEngine;
using System.Collections;

namespace NWR.Modules
{
    public class Player : MonoBehaviour
    {
        public static Player Instance { get; private set; }

        [SerializeField] public uint money;
        [SerializeField] public uint donation;
        [SerializeField] public ushort selectedCarID;
        [SerializeField] public ushort selectedRoadID;
        [SerializeField] public ushort selectedGameModeID;

        [SerializeField] public PlayerSelectedItemIDs listOfPlayerSelectedItemsIDs;
        [SerializeField] public PlayerBoughtedItemsIDs listOfPurchasedItemIDs;

        [Serializable]
        public class PlayerBoughtedItemsIDs
        {
            [SerializeField, ReadOnly] public List<int> boughtCars;
            [SerializeField, ReadOnly] public List<int> boughtRoads;

            public PlayerBoughtedItemsIDs(List<int> car_IDs, List<int> road_IDs)
            {
                this.boughtCars = car_IDs;
                this.boughtRoads = road_IDs;
            }

            public void AddNewBoughtCar(int boughtCarID)
            {
                boughtCars.Add(boughtCarID);
            }
            public void AddNewBoughtRoad(int boughtRoadID)
            {
                boughtRoads.Add(boughtRoadID);
            }
        }

        public class PlayerSelectedItemIDs
        {
            public ushort car_ID;
            public ushort road_ID;
            public ushort gameMode_ID;

            public PlayerSelectedItemIDs(ushort car_ID, ushort road_ID, ushort gameMode_ID)
            {
                this.car_ID = car_ID;
                this.road_ID = road_ID;
                this.gameMode_ID = gameMode_ID;
            }
        }

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this.gameObject);
        }

        void Start()
        {
            LoadPlayerDataOnStart();

            Assets.Instance.LoadPurchasedItems(in listOfPurchasedItemIDs);
            Assets.Instance.FindFromAssetsAndSendItems(listOfPlayerSelectedItemsIDs);
            UpdateUI_PlayerStats();
        }


        private void LoadPlayerDataOnStart()
        {
            DataToSaveAndLoad loadedData = LoadSystem.Load();

            money = loadedData.money;

            selectedCarID = loadedData.selectedCarID;
            selectedRoadID = loadedData.selectedRoadID;
            selectedGameModeID = loadedData.selectedGameModeID;

            listOfPurchasedItemIDs = new PlayerBoughtedItemsIDs(new List<int>(loadedData.ID_OfAllPurchasedCars), new List<int>(loadedData.ID_OfAllPurchasedRoads));
            listOfPlayerSelectedItemsIDs = new PlayerSelectedItemIDs(selectedCarID, selectedRoadID, selectedGameModeID);
        }



        public void ChangeSelectedCar(ushort newCarID)
        {
            selectedCarID = newCarID;
            Car newCar = Assets.Instance.cars_list.First(x => x.item.GetID() == newCarID).item;
            LobbyManager.Instance.UpdatePlayerCar(newCar);
        }

        public void UpdateUI_PlayerStats()
        {
            UI_Manager.Instance.UpdateUI_PlayerStats(money, donation);
        }
    }
}
