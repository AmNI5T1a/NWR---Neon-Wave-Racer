using System;
using UnityEngine;
using NWR.Modules;

namespace NWR.Lobby
{
    public class UI_Manager : MonoBehaviour
    {
        public static UI_Manager Instance { get; private set; }

        public static event Action<uint, uint> OnSendPlayerStats;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this.gameObject);
        }

        public void UpdateUI_PlayerStats(uint money, uint donation)
        {
            OnSendPlayerStats?.Invoke(money, donation);
        }
    }
}
