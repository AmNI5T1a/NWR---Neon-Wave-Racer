using UnityEngine;

namespace NWR.Lobby
{

    public class UI_BuyCar : MonoBehaviour, I_UI_ItemBuyer
    {
        public void BuyItem()
        {
            Debug.Log("Logiic for buy this car");
        }
    }
}