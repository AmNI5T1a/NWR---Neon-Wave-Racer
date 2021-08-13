using UnityEngine;
using NWR.Modules;
using TMPro;

namespace NWR.Lobby
{
    class UI_CreateGameModeItem : MonoBehaviour, I_UI_ItemCreator
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
            var gameModeItemTemplate = Resources.Load("GameMode item-template");
            GameObject itemInstance = Instantiate(gameModeItemTemplate, this.gameObject.transform) as GameObject;

            UI_ChooseGameModeItem ui_gameModeItemChooser = itemInstance.AddComponent<UI_ChooseGameModeItem>();
            ui_gameModeItemChooser.gameModeToChoose = instance.item;
            itemInstance.AddComponent<UI_ItemChooser>();

            itemInstance.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = instance.item.GetName();
        }
    }
}