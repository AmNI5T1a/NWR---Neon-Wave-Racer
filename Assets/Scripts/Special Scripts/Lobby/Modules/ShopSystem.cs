using UnityEngine;
using TMPro;
using NWR.Modules;

namespace NWR.Lobby
{
    public class ShopSystem : Singleton<ShopSystem>
    {
        [Header("Info box: ")]
        [ReadOnly, SerializeField] public bool previewModeActive = false;

        [Space(10)]

        [ReadOnly, SerializeField] public GameObject carForPreview;
        [ReadOnly, SerializeField] public GameObject preview_UI_Component;
        [ReadOnly, SerializeField] public GameObject buyButton_UI_Component;

        public void ShopSystemConstructor(ref GameObject carForPreview, ref GameObject preview_UI_Component, ref GameObject buyButton_UI_Component)
        {
            this.carForPreview = carForPreview;
            this.preview_UI_Component = preview_UI_Component;
            this.buyButton_UI_Component = buyButton_UI_Component;
        }



        public void ClosePreviewMode()
        {
            Debug.Log("Closing preview mode");

            LobbyManager.Instance.playerCarGameObject.SetActive(true);

            Destroy(carForPreview);
            Destroy(preview_UI_Component);
            Destroy(buyButton_UI_Component);
        }
    }
}