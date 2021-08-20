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
            if (ShopSystem.Instance.previewModeActive)
                ShopSystem.Instance.ClosePreviewMode();


            Player.Instance.ChangeSelectedCar(carToChoose.GetID());
        }
    }
}