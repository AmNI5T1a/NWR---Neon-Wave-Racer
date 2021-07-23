using System.Collections.Generic;
using UnityEngine;
using NWR.Modules;
using TMPro;

namespace NWR.Lobby
{
    class UI_CreateCarItem : MonoBehaviour, I_UI_ItemCreator
    {
        public void CreateItem(Assets.OnSendItemsEventArgs items)
        {
            foreach (Assets.ItemAndStats<Car> car in items.cars_List)
            {
                if (!car.isBought)
                {
                    var item_template_prefab = Resources.Load("Car item-template");
                    GameObject obj = Instantiate(item_template_prefab, this.gameObject.transform) as GameObject;

                    UI_BuyAnItem buyAnItem_instance = obj.AddComponent<UI_BuyAnItem>();
                    UI_BuyCar buyCar_instance = obj.AddComponent<UI_BuyCar>();
                    buyCar_instance.carToBuy = car.item;

                    obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = car.item.GetName();
                }
                else
                {
                    var item_template_prefab = Resources.Load("Car item-template");
                    GameObject obj = Instantiate(item_template_prefab, this.gameObject.transform) as GameObject;

                    UI_ChooseAnItem chooseAnItem_instance = obj.AddComponent<UI_ChooseAnItem>();
                    chooseAnItem_instance.UI_ChooseAnItemConstructor(instance: car);
                    obj.AddComponent<UI_ChooseCarItem>();


                    obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = car.item.GetName();
                }
            }
        }
    }
}