using System.Collections.Generic;
using UnityEngine;
using NWR.Modules;

namespace NWR.Lobby
{
    [RequireComponent(typeof(I_UI_ItemCreator), typeof(I_UI_ItemUpdater))]
    public class UI_CreateItem : MonoBehaviour
    {
        void Awake()
        {
            Assets.OnSendAssets += CreateItemsAtStart;
        }

        private void CreateItemsAtStart(object sender, Assets.OnSendAssetsEventArgs assets)
        {
            I_UI_ItemCreator creator = this.gameObject.GetComponent<I_UI_ItemCreator>();
            creator.CreateItemsAtStart(assets);
        }

        private void UpdateItemInUIComponent<T>(T item) where T : Item
        {
            I_UI_ItemUpdater updater = this.gameObject.GetComponent<I_UI_ItemUpdater>();
            updater.UpdateUIComponent(item);
        }
    }
}