using UnityEngine;
using NWR.Modules;
using TMPro;

namespace NWR.Lobby
{
    [RequireComponent(typeof(I_UI_CreateDeleteItem))]
    public class UI_CreateDeleteItem : MonoBehaviour
    {
        void Awake()
        {
            Assets.OnSendItems += Create;
        }


        private void Create(object sender, Assets.OnSendItemsEventArgs e)
        {
            I_UI_CreateDeleteItem instance = this.gameObject.GetComponent<I_UI_CreateDeleteItem>();

            if (instance == null)
            {
                Debug.LogError("UI_ItemCreator script doesn't found class that realizes I_UI_ItemCreator interface...");
            }
            else
            {
                instance.CreateItem(e);
            }
        }
    }
}
