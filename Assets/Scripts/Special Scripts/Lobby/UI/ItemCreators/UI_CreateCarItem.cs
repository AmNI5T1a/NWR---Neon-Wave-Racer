using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using NWR.Modules;
using TMPro;

namespace NWR.Lobby
{
    public class UI_CreateCarItem : MonoBehaviour, I_UI_ItemCreator, I_UI_ItemUpdater
    {
        public Dictionary<Car, GameObject> car_ui_gmComponents = new Dictionary<Car, GameObject>();
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
                CreateBoughtItem(instance.item, ref gameObject_instance);
            }
            else
                CreatePurchasableItem(instance.item, ref gameObject_instance);

            gameObject_instance.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = instance.item.GetName();

            car_ui_gmComponents.Add(instance.item, gameObject_instance);
        }


        private void CreateBoughtItem(Car car, ref GameObject UI_Component_instance)
        {
            UI_ChooseCarItem ui_carItemChooser = UI_Component_instance.gameObject.AddComponent<UI_ChooseCarItem>();
            ui_carItemChooser.carToChoose = car;

            UI_ItemChooser ui_itemChooser = UI_Component_instance.gameObject.AddComponent<UI_ItemChooser>();
        }

        private void CreatePurchasableItem(Car car, ref GameObject UI_Component_instance)
        {
            UI_BuyCar ui_carItemBuyer = UI_Component_instance.gameObject.AddComponent<UI_BuyCar>();
            ui_carItemBuyer.carToBuy = car;
            ui_carItemBuyer.creator = this;

            UI_BuyAnItem ui_itemBuyer = UI_Component_instance.gameObject.AddComponent<UI_BuyAnItem>();
        }
        public void UpdateUIComponent<T>(T item) where T : Item
        {
            GameObject carGameObjectToUpdate = car_ui_gmComponents.First(x => x.Key.GetID() == item.GetID()).Value;
            Car carToUpdate = car_ui_gmComponents.First(x => x.Key.GetID() == item.GetID()).Key;

            car_ui_gmComponents.Remove(carToUpdate);
            Destroy(carGameObjectToUpdate);

            Assets.ItemAndStats<Car> itemToUpdate = new Assets.ItemAndStats<Car>();
            itemToUpdate.item = carToUpdate;
            itemToUpdate.isBought = true;

            CreateUIComponent(itemToUpdate);
        }
    }
}