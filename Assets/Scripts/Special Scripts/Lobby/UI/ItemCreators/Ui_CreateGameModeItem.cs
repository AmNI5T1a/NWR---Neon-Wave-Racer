using System.Collections.Generic;
using UnityEngine;
using NWR.Modules;
using TMPro;

namespace NWR.Lobby
{
    class UI_CreateGameModeItem : MonoBehaviour, I_UI_ItemCreator, I_UI_ItemUpdater
    {
        public void CreateItemsAtStart(Assets.OnSendAssetsEventArgs assets)
        {
            foreach (Assets.ItemAndStats<GameMode> instance in assets.gameModes_List)
            {
                CreateUIComponent(instance: instance);
            }
        }


        public void CreateUIComponent(Assets.ItemAndStats<GameMode> instance)
        {
            var item_template_prefab = Resources.Load("GameMode item-template");
            GameObject gameObject_instance = Instantiate(item_template_prefab, this.gameObject.transform) as GameObject;

            UI_ChooseGameModeItem ui_chooseGameModeItem = this.gameObject.AddComponent<UI_ChooseGameModeItem>();
            ui_chooseGameModeItem.gameModeToChoose = instance.item;

            UI_ItemChooser ui_itemChooser = this.gameObject.AddComponent<UI_ItemChooser>();

            gameObject_instance.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = instance.item.GetName();
        }

        public void UpdateUIComponent<T>(T item) where T : Item
        {
            throw new System.NotImplementedException();
        }
    }
}