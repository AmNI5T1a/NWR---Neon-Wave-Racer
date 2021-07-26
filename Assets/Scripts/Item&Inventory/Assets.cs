using System;
using System.Collections.Generic;
using UnityEngine;
using NWR.Lobby;

namespace NWR.Modules
{
    public class Assets : MonoBehaviour
    {
        public static Assets Instance;


        [System.Serializable]
        public class ItemAndStats<T> where T : Item
        {
            [SerializeField] public T item;
            [SerializeField] public bool isBought;
        }
        [SerializeField] public List<ItemAndStats<Car>> cars_list;
        [SerializeField] public List<ItemAndStats<Road>> roads_list;
        [SerializeField] public List<ItemAndStats<GameMode>> gameModes_list;



        public static event EventHandler<OnSendPlayerSelectedItemsEventArgs> OnSendPlayerSelectedItems;
        public class OnSendPlayerSelectedItemsEventArgs : EventArgs
        {
            public ItemAndStats<Car> playerCar;
            public ItemAndStats<Road> playerRoad;
            public ItemAndStats<GameMode> playerGameMode;
        }



        public static event EventHandler<OnSendItemsEventArgs> OnSendItems;
        public class OnSendItemsEventArgs : EventArgs
        {
            public List<ItemAndStats<Car>> cars_List;
            public List<ItemAndStats<Road>> roads_List;
            public List<ItemAndStats<GameMode>> gameModes_List;
        }

        void Awake()
        {
            Player.OnSendBoughtItemIDs += LoadPurchasedItems;

            Player.OnSendPlayerSelectedItemIDs += FindAndSendItemsInformation;
        }

        void Start()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this.gameObject);

            OnSendItems?.Invoke(this, new OnSendItemsEventArgs
            {
                cars_List = this.cars_list,
                roads_List = this.roads_list,
                gameModes_List = this.gameModes_list
            });
        }

        private void LoadPurchasedItems(object sender, Player.ID_ListsOfPurchasedItems lists)
        {
            foreach (ItemAndStats<Car> item in cars_list)
            {
                item.isBought = lists.boughtCars.Contains(item.item.GetID());
            }

            foreach (ItemAndStats<Road> item in roads_list)
            {
                item.isBought = lists.boughtRoads.Contains(item.item.GetID());
            }
        }

        private void FindAndSendItemsInformation(object sender, Player.PlayerSelectedItemIDsEventArgs e)
        {
            OnSendPlayerSelectedItemsEventArgs playerItems = new OnSendPlayerSelectedItemsEventArgs();

            foreach (ItemAndStats<Car> car in cars_list)
            {
                if (car.item.GetID() == e.car_ID)
                {
                    playerItems.playerCar = car;
                }
            }


            foreach (ItemAndStats<Road> road in roads_list)
            {
                if (road.item.GetID() == e.road_ID)
                {
                    playerItems.playerRoad = road;
                }
            }

            foreach (ItemAndStats<GameMode> gm in gameModes_list)
            {
                if (gm.item.GetID() == e.gameMode_ID)
                {
                    playerItems.playerGameMode = gm;
                }
            }

            OnSendPlayerSelectedItems?.Invoke(this, playerItems);
        }
    }
}

