using TMPro;

using NWR.Modules;

namespace NWR.Lobby
{
    public class UI_RoadTextBoxUpdater : UI_UpdateTextBoxInfo_Factory
    {
        public override void UpdateText(Assets.PlayerSelectedItemsEventArgs e)
        {
            this.gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = e.playerRoad.item.GetName();
        }
    }
}