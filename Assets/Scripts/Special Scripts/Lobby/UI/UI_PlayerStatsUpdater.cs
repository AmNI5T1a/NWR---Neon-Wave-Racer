using UnityEngine;
using TMPro;
using NWR.Modules;

namespace NWR.Lobby
{
    public class UI_PlayerStatsUpdater : MonoBehaviour
    {
        void Awake()
        {
            UI_Manager.OnSendPlayerStats += UpdateStats;
        }

        private void UpdateStats(uint money, uint donate)
        {
            this.gameObject.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = money.ToString();
            this.gameObject.transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text = donate.ToString();
        }
        public void UpdatePlayerMoneyScore(uint money)
        {
            this.gameObject.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = money.ToString();
        }

        public void UpdatePlayerDonationScore(uint donate)
        {
            this.gameObject.transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text = donate.ToString();
        }
    }
}