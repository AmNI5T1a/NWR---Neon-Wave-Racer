using System.Collections.Generic;
using UnityEngine;
using NWR.Modules;
using TMPro;

namespace NWR.Lobby
{
    class UI_CreateRoadItem : MonoBehaviour, I_UI_ItemCreator, I_UI_ItemUpdater
    {
        public void CreateItemsAtStart(Assets.OnSendAssetsEventArgs assets)
        {
            foreach (Assets.ItemAndStats<Road> instance in assets.roads_List)
            {
                CreateUIComponent(instance);
            }
        }


        public void CreateUIComponent(Assets.ItemAndStats<Road> instance)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateUIComponent<T>(Assets.ItemAndStats<T> instance) where T : Item
        {
            throw new System.NotImplementedException();
        }

        public void UpdateUIComponent<T>(T item) where T : Item
        {
            throw new System.NotImplementedException();
        }
    }
}