using System;
using System.Linq;
using System.Collections.Generic;
using NWR.Lobby;
using UnityEngine;

namespace NWR.Modules
{
    public class Player : MonoBehaviour
    {
        public static Player Instance { get; private set; }

        public uint money;
        public uint donation;
        public ushort selectedCarID;
        public ushort selectedRoadID;
        public ushort selectedGameModeID;
        public ID_ListsOfPurchasedItems listOfPurchasedItemIDs;

        public static event Action<uint, uint> OnSendPlayerStats = delegate { };

        public static EventHandler<ID_ListsOfPurchasedItems> OnSendBoughtItemIDs;
        public class ID_ListsOfPurchasedItems
        {
            public List<int> boughtCars { get; set; }
            public List<int> boughtRoads { get; set; }

            public ID_ListsOfPurchasedItems(List<int> car_IDs, List<int> road_IDs)
            {
                this.boughtCars = car_IDs;
                this.boughtRoads = road_IDs;
            }
        }

        public static EventHandler<PlayerSelectedItemIDsEventArgs> OnSendPlayerSelectedItemIDs;
        public class PlayerSelectedItemIDsEventArgs : EventArgs
        {
            public ushort car_ID;
            public ushort road_ID;
            public ushort gameMode_ID;
        }



        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        void Start()
        {
            LoadPlayerDataOnStart();

            OnSendBoughtItemIDs?.Invoke(this, listOfPurchasedItemIDs);

            OnSendPlayerSelectedItemIDs?.Invoke(this, new PlayerSelectedItemIDsEventArgs
            {
                car_ID = selectedCarID,
                road_ID = selectedRoadID,
                gameMode_ID = selectedGameModeID

            });

            UpdatePlayerStats();
        }


        private void LoadPlayerDataOnStart()
        {
            DataToSaveAndLoad loadedData = LoadSystem.Load();

            money = loadedData.money;

            selectedCarID = loadedData.selectedCarID;
            selectedRoadID = loadedData.selectedRoadID;
            selectedGameModeID = loadedData.selectedGameModeID;

            listOfPurchasedItemIDs = new ID_ListsOfPurchasedItems(new List<int>(loadedData.ID_OfAllPurchasedCars), new List<int>(loadedData.ID_OfAllPurchasedRoads));
        }


        public void ChangeSelectedCar(ushort newCarID)
        {
            this.selectedCarID = newCarID;
            Car newCar = Assets.Instance.cars_list.First(x => x.item.GetID() == newCarID).item;
            LobbyManager.Instance.UpdatePlayerCar(newCar);
        }

        public void UpdatePlayerStats()
        {
            OnSendPlayerStats(Instance.money, Instance.donation);
        }
    }
}
