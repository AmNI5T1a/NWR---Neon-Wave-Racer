using UnityEngine;
using TMPro;
using NWR.Modules;

public class UI_PlayerStatsUpdater : MonoBehaviour
{
    public static UI_PlayerStatsUpdater Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);


        Player.OnSendPlayerStats += UpdateStatsAtStart;
    }

    private void UpdateStatsAtStart(uint money, uint donate)
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
