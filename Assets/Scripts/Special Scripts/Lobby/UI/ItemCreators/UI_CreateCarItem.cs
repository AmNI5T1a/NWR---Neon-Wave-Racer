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

                    UI_BuyAnItem script = obj.AddComponent<UI_BuyAnItem>();
                    UI_BuyCar carBuyScript = obj.AddComponent<UI_BuyCar>();

                    obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = car.item.GetName();
                }
                else
                {
                    var item_template_prefab = Resources.Load("Car item-template");
                    GameObject obj = Instantiate(item_template_prefab, this.gameObject.transform) as GameObject;

                    Debug.Log("UI_CreateCarItem script:  Not implemented exception");

                    obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = car.item.GetName();
                }
            }
        }
    }
}