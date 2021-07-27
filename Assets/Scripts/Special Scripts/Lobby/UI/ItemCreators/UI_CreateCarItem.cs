using System.Collections.Generic;
using UnityEngine;
using NWR.Modules;
using TMPro;
using System;

namespace NWR.Lobby
{
    class UI_CreateCarItem : MonoBehaviour, I_UI_ItemCreator, I_UI_ItemUpdater
    {
        public void CreateItemsAtStart(Assets.OnSendAssetsEventArgs assets)
        {
            foreach (Assets.ItemAndStats<Car> car in assets.cars_List)
            {
                CreateUIComponent(car);
            }
        }

        public void CreateUIComponent(Assets.ItemAndStats<Car> instance)
        {
            var item_template_prefab = Resources.Load("Car item-template");
            GameObject gameObject_instance = Instantiate(item_template_prefab, this.gameObject.transform) as GameObject;

            if (instance.isBought)
            {
                CreateBoughtItem(instance.item);
            }
            else
                CreatePurchasableItem(instance.item);


            gameObject_instance.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = instance.item.GetName();
        }


        private void CreateBoughtItem(Car car)
        {
            UI_ChooseCarItem ui_carItemChooser = this.gameObject.AddComponent<UI_ChooseCarItem>();
            ui_carItemChooser.carToChoose = car;

            UI_ItemChooser ui_itemChooser = this.gameObject.AddComponent<UI_ItemChooser>();
        }

        private void CreatePurchasableItem(Car car)
        {
            UI_BuyCar ui_carItemBuyer = this.gameObject.AddComponent<UI_BuyCar>();
            ui_carItemBuyer.carToBuy = car;

            UI_BuyAnItem ui_itemBuyer = this.gameObject.AddComponent<UI_BuyAnItem>();
            ui_itemBuyer.Buy(ui_carItemBuyer);
        }



        public void UpdateUIComponent<T>(Assets.ItemAndStats<T> instance) where T : Item
        {
            throw new NotImplementedException();
        }
    }
}