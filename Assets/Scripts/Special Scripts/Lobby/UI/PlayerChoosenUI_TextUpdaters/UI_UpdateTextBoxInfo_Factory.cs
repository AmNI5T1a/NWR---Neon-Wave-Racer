using UnityEngine;

using TMPro;

using NWR.Modules;

namespace NWR.Lobby
{
    public abstract class UI_UpdateTextBoxInfo_Factory : MonoBehaviour
    {
        public abstract void UpdateText(Assets.OnSendPlayerSelectedItemsEventArgs e);
    }
}