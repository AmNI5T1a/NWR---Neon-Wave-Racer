using System.Collections.Generic;
using NWR.Lobby;
using UnityEngine;
using System.Linq;

namespace NWR.Modules
{
    [CreateAssetMenu(fileName = "Car", menuName = "NWR/Items/Car")]
    public class Car : Item
    {
        [SerializeField] private uint price;
        [SerializeField] private string description;
        [SerializeField] private GameObject prefab;



        public uint GetPrice() => price;
        public GameObject GetCarAsGameObject() => prefab;
        public void Buy()
        {
            // TODO: -money to player
            // TODO: Add car to bought IDs list
            // TODO: Close preview mode
            // TODO: update UI
            // TODO: set this as selected
            // TODO: save game

            if (Player.Instance.money >= price)
            {
                Player.Instance.money -= price;

                Player.Instance.listOfPurchasedItemIDs.boughtCars.Add(this.GetID());

                Assets.ItemAndStats<Car> car = Assets.Instance.cars_list.First(x => x.item.GetID() == this.GetID());
                car.isBought = true;

                Player.Instance.ChangeSelectedCar(this.GetID());

                ShopSystem.Instance.ClosePreviewMode();
                Player.Instance.UpdatePlayerStats();
            }
            else
            {
                Debug.Log("Player doesn't have enough money");
                Debug.LogWarning("Notification window not implemented exception");
            }
        }
    }
}
