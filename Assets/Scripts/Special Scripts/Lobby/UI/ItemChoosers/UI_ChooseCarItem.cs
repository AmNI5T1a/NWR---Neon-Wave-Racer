using UnityEngine;
using NWR.Modules;

namespace NWR.Lobby
{

    public class UI_ChooseCarItem : MonoBehaviour, I_UI_ItemChooser
    {
        public void ChooseThisItem(Assets.ItemAndStats<Car> carInstance)
        {
            if (carInstance.item == LobbyManager.Instance.playerCar)
            {
                if (ShopSystem.Instance.previewModeActive)
                    ShopSystem.Instance.ClosePreviewMode();
                return;
            }


            LobbyManager.Instance.playerCarGameObject = carInstance.item.GetCarAsGameObject();
            LobbyManager.Instance.playerCar = carInstance.item;
        }
    }
}