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
            // TODO: save game

            if (Player.Instance.money >= price)
            {
                Player.Instance.money -= price;
                Player.Instance.listOfPurchasedItemIDs.boughtCars.Add(this.GetID());
                ShopSystem.Instance.ClosePreviewMode();
                GameObject gm = UI_CreateCarItem.car_ui_gmComponents.First(x => x.Key.GetID() == this.GetID()).Value;
                DestroyImmediate(gm);
                /*SaveSystem.Save();*/
            }
            else
            {
                Debug.Log("Player doesn't have enough money");
                Debug.LogWarning("Notification window not implemented exception");
            }
        }
    }
}
