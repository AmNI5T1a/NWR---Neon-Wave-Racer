using UnityEngine;
using NWR.Modules;

namespace NWR.Lobby
{

    public class UI_ChooseCarItem : MonoBehaviour, I_UI_ItemChooser
    {
        public void ChooseThisItem(Assets.ItemAndStats<Car> carInstance)
        {
            if (carInstance.item == LobbyManager.Instance.playerCar)
                return;

            if (ShopSystem.Instance.previewModeActive == true)
                ShopSystem.Instance.ClosePreviewMode();

            LobbyManager.Instance.playerCarGameObject = carInstance.item.GetCarAsGameObject();
            LobbyManager.Instance.playerCar = carInstance.item;
        }
    }
}