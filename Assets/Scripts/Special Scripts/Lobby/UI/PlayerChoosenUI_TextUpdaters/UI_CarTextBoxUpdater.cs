using TMPro;

using NWR.Modules;

namespace NWR.Lobby
{
    public class UI_CarTextBoxUpdater : UI_UpdateTextBoxInfo_Factory
    {
        private void Awake()
        {
            UI_Manager.OnUpdatePlayerSelectedCar += UpdateChoosenCarInUIComponent;
        }

        private void UpdateChoosenCarInUIComponent(Car car)
        {
            this.gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = car.GetName().ToString();
        }

        public override void UpdateText(Assets.PlayerSelectedItemsEventArgs e)
        {
            this.gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = e.playerCar.item.GetName();
        }
    }
}