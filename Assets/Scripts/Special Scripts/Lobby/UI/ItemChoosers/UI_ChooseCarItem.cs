using UnityEngine;
using NWR.Modules;

namespace NWR.Lobby
{

    public class UI_ChooseCarItem : MonoBehaviour, I_UI_ItemChooser
    {
        [Header("Info")]
        [ReadOnly, SerializeField] public Car carToChoose;
        public void ChooseThisItem()
        {
            if (carToChoose == LobbyManager.Instance.playerCar)
            {
                if (ShopSystem.Instance.previewModeActive)
                    ShopSystem.Instance.ClosePreviewMode();
                return;
            }


            LobbyManager.Instance.playerCarGameObject = carToChoose.GetCarAsGameObject();
            LobbyManager.Instance.playerCar = carToChoose;
        }
    }
}