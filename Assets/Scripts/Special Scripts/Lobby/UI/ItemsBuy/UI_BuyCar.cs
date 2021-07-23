using UnityEngine;
using TMPro;
using NWR.Modules;

namespace NWR.Lobby
{

    public class UI_BuyCar : MonoBehaviour, I_UI_ItemPreview
    {
        [Header("Info box: ")]
        [ReadOnly, SerializeField] public Car carToBuy;
        public void PreviewItem()
        {
            LobbyManager.Instance.playerCarGameObject.SetActive(false);

            GameObject previewMode_UI_Component = Instantiate(Resources.Load("Preview Mode UI Component"), this.gameObject.transform) as GameObject;

            GameObject carForPreview = Instantiate(carToBuy.GetCarAsGameObject(), LobbyManager.Instance.playerCarPosition, Quaternion.identity);

            GameObject buyButton_UI_Component = Instantiate(Resources.Load("Buy button"), this.gameObject.transform) as GameObject;
            buyButton_UI_Component.gameObject.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = carToBuy.GetPrice().ToString();

            ShopSystem.Instance.ShopSystemConstructor(carForPreview: ref carForPreview,
                                                    preview_UI_Component: ref previewMode_UI_Component,
                                                    buyButton_UI_Component: ref buyButton_UI_Component);
        }
    }
}