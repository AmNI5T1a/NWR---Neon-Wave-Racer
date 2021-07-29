using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NWR.Modules;

namespace NWR.Lobby
{

    public class UI_BuyCar : MonoBehaviour, I_UI_ItemBuy
    {
        [Header("Info box: ")]
        [ReadOnly, SerializeField] public Car carToBuy;
        [ReadOnly, SerializeField] public UI_CreateCarItem creator;
        public void BuyItem()
        {
            if (ShopSystem.Instance.previewModeActive)
                ShopSystem.Instance.ClosePreviewMode();

            LobbyManager.Instance.playerCarGameObject.SetActive(false);

            GameObject previewMode_UI_Component = Instantiate(Resources.Load("Preview Mode UI Component"), this.gameObject.transform.root) as GameObject;
            previewMode_UI_Component.transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text = carToBuy.GetName().ToString();

            GameObject carForPreview = Instantiate(carToBuy.GetCarAsGameObject(), LobbyManager.Instance.playerCarPosition, Quaternion.identity);

            GameObject buyButton_UI_Component = Instantiate(Resources.Load("Buy button"), this.gameObject.transform.root) as GameObject;
            buyButton_UI_Component.gameObject.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = carToBuy.GetPrice().ToString();
            buyButton_UI_Component.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(delegate { carToBuy.Buy(this); });

            ShopSystem.Instance.ShopSystemConstructor(carForPreview: ref carForPreview,
                                                    preview_UI_Component: ref previewMode_UI_Component,
                                                    buyButton_UI_Component: ref buyButton_UI_Component);
        }
    }
}