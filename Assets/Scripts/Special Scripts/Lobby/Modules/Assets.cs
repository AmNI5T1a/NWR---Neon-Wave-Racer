using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace NWR.Modules
{
    public class Assets : MonoBehaviour
    {
        public static Assets Instance { get; private set; }

        [System.Serializable]
        public class ItemAndStats<T> where T : Item
        {
            [SerializeField] public T item;
            [SerializeField] public bool isBought;
        }
        [SerializeField] public List<ItemAndStats<Car>> cars_list = new List<ItemAndStats<Car>>();
        [SerializeField] public List<ItemAndStats<Road>> roads_list;
        [SerializeField] public List<ItemAndStats<GameMode>> gameModes_list;



        public static event EventHandler<PlayerSelectedItemsEventArgs> OnSendPlayerSelectedItems;
        public class PlayerSelectedItemsEventArgs : EventArgs
        {
            public ItemAndStats<Car> playerCar;
            public ItemAndStats<Road> playerRoad;
            public ItemAndStats<GameMode> playerGameMode;
        }



        public static event EventHandler<OnSendAssetsEventArgs> OnSendAssets;
        public class OnSendAssetsEventArgs : EventArgs
        {
            public List<ItemAndStats<Car>> cars_List;
            public List<ItemAndStats<Road>> roads_List;
            public List<ItemAndStats<GameMode>> gameModes_List;

            public OnSendAssetsEventArgs(List<ItemAndStats<Car>> cars_List, List<ItemAndStats<Road>> roads_List, List<ItemAndStats<GameMode>> gameModes_List)
            {
                this.cars_List = cars_List;
                this.roads_List = roads_List;
                this.gameModes_List = gameModes_List;
            }
        }


        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this.gameObject);
        }

        public void LoadPurchasedItemsOnStart(in Player.PlayerBoughtedItemsIDs listOfLoadedBoughtItems)
        {
            SetPurchasedItems(listOfLoadedBoughtItems);

            OnSendAssetsEventArgs assets = new OnSendAssetsEventArgs(cars_list, roads_list, gameModes_list);
            OnSendAssets?.Invoke(this, assets);
        }

        public void FindFromAssetsAndSendItemsOnStart(Player.PlayerSelectedItemIDs e)
        {
            PlayerSelectedItemsEventArgs items = FindPlayerSelectedItemsFromAssets(e);
            OnSendPlayerSelectedItems?.Invoke(this, items);
        }



        public void SetPurchasedItems(in Player.PlayerBoughtedItemsIDs lists)
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

        public PlayerSelectedItemsEventArgs FindPlayerSelectedItemsFromAssets(Player.PlayerSelectedItemIDs e)
        {
            PlayerSelectedItemsEventArgs playerItems = new PlayerSelectedItemsEventArgs();

            playerItems.playerCar = cars_list.First(x => x.item.GetID() == e.car_ID);
            playerItems.playerRoad = roads_list.First(x => x.item.GetID() == e.road_ID);
            playerItems.playerGameMode = gameModes_list.Find(x => x.item.GetID() == e.gameMode_ID);

            return playerItems;
        }
    }
}

