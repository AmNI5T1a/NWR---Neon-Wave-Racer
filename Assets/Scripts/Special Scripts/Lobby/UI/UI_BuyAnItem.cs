using UnityEngine;
using UnityEngine.UI;

namespace NWR.Lobby
{
    [RequireComponent(typeof(I_UI_ItemBuyer))]
    public class UI_BuyAnItem : MonoBehaviour
    {
        void Start()
        {
            Button btn = this.gameObject.transform.GetChild(1).GetComponent<Button>();
            btn.onClick.AddListener(() => Buy(this.gameObject.GetComponent<I_UI_ItemBuyer>()));
        }

        private void Buy(I_UI_ItemBuyer buyer)
        {
            buyer.BuyItem();
        }
    }
}
