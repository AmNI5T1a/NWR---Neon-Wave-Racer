using UnityEngine;
using NWR.Modules;

namespace NWR.Lobby
{
    [RequireComponent(typeof(UI_UpdateTextBoxInfo_Factory))]
    public class UI_UpdateTextForChoosenItems : MonoBehaviour
    {
        void Awake()
        {
            Assets.OnSendPlayerSelectedItems += SetNewText;
        }
        public void SetNewText(object sender, Assets.OnSendPlayerSelectedItemsEventArgs e)
        {
            this.gameObject.GetComponent<UI_UpdateTextBoxInfo_Factory>().UpdateText(e);
        }
    }
}
