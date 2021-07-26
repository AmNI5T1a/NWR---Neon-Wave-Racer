using System.Collections.Generic;
using NWR.Lobby;
using UnityEngine;
using System.Linq;

namespace NWR.Modules
{
    [CreateAssetMenu(fileName = "Car", menuName = "NWR/Items/Car")]
    public class Car : Item, IBuyItem
    {
        [SerializeField] private uint price;
        [SerializeField] private string description;
        [SerializeField] private GameObject prefab;


        public GameObject GetCarAsGameObject() => prefab;
        public uint GetPrice() => price;
        public void Buy()
        {
            if (Player.Instance.money >= this.GetPrice())
            {
                // TODO: add to player bought cars list
                // TODO: check box to true in assets cars_list
                // TODO: update UI for this item
                // TODO: save system
                // TODO: set this car as choosen
                // TODO: close UI
                // TODO: delete preview and buy button

                Player.Instance.listOfPurchasedItemIDs.boughtCars.Add(this.GetID());
                Assets.ItemAndStats<Car> car = Assets.Instance.cars_list.FirstOrDefault(x => this.ID == GetID());
                Debug.Log("car with name: " + car.item.name + "isBought was sucessuly set as true");
                car.isBought = true;


                //SaveSystem.Save();
            }
            else
            {
                Debug.LogWarning("Car: not enought money");
                Debug.LogWarning("Notification window: Not implemented exception");
            }
        }
    }
}
