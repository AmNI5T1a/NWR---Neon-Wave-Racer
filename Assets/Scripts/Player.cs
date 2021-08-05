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
        public ListOfIDs_ofPurchasedItems listOfPurchasedItemIDs;
        public PlayerSelectedItemIDsEventArgs listOfPlayerSelectedItemsIDs;

        public static event Action<uint, uint> OnSendPlayerStats = delegate { };

        public static EventHandler<ListOfIDs_ofPurchasedItems> OnSendBoughtItemIDs;
        public class ListOfIDs_ofPurchasedItems
        {
            public List<int> boughtCars { get; set; }
            public List<int> boughtRoads { get; set; }

            public ListOfIDs_ofPurchasedItems(List<int> car_IDs, List<int> road_IDs)
            {
                this.boughtCars = car_IDs;
                this.boughtRoads = road_IDs;
            }
        }

        public static EventHandler<PlayerSelectedItemIDsEventArgs> OnSendPlayerSelectedItemIDs;
        public class PlayerSelectedItemIDsEventArgs
        {
            public ushort car_ID;
            public ushort road_ID;
            public ushort gameMode_ID;

            public PlayerSelectedItemIDsEventArgs(ushort car_ID, ushort road_ID, ushort gameMode_ID)
            {
                this.car_ID = car_ID;
                this.road_ID = road_ID;
                this.gameMode_ID = gameMode_ID;
            }
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
            OnSendPlayerSelectedItemIDs?.Invoke(this, listOfPlayerSelectedItemsIDs);
            UpdatePlayerStats();
        }


        private void LoadPlayerDataOnStart()
        {
            DataToSaveAndLoad loadedData = LoadSystem.Load();

            money = loadedData.money;

            selectedCarID = loadedData.selectedCarID;
            selectedRoadID = loadedData.selectedRoadID;
            selectedGameModeID = loadedData.selectedGameModeID;

            listOfPurchasedItemIDs = new ListOfIDs_ofPurchasedItems(new List<int>(loadedData.ID_OfAllPurchasedCars), new List<int>(loadedData.ID_OfAllPurchasedRoads));
            listOfPlayerSelectedItemsIDs = new PlayerSelectedItemIDsEventArgs(selectedCarID, selectedRoadID, selectedGameModeID);
        }



        public void ChangeSelectedCar(ushort newCarID)
        {
            selectedCarID = newCarID;
            Car newCar = Assets.Instance.cars_list.First(x => x.item.GetID() == newCarID).item;
            LobbyManager.Instance.UpdatePlayerCar(newCar);
        }

        public void UpdatePlayerStats()
        {
            OnSendPlayerStats?.Invoke(money, donation);
        }
    }
}
