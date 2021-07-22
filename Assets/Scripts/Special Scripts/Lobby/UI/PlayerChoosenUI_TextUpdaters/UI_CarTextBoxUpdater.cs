using TMPro;

using NWR.Modules;

namespace NWR.Lobby
{
    public class UI_CarTextBoxUpdater : UI_UpdateTextBoxInfo_Factory
    {
        public override void UpdateText(Assets.OnSendPlayerSelectedItemsEventArgs e)
        {
            this.gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = e.playerCar.item.GetName();
        }
    }
}