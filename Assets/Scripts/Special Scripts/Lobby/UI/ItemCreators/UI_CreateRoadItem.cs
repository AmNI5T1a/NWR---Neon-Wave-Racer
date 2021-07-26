using System.Collections.Generic;
using UnityEngine;
using NWR.Modules;
using TMPro;

namespace NWR.Lobby
{
    class UI_CreateRoadItem : MonoBehaviour, I_UI_CreateDeleteItem
    {
        public void CreateItem(Assets.OnSendItemsEventArgs items)
        {
            Debug.LogError("UI_CreateRoadUtem not implemented");
        }

        public void DeleteItem<T>(T item) where T : Item
        {
            throw new System.NotImplementedException();
        }
    }
}