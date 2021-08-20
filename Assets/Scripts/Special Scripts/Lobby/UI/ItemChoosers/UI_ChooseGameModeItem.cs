using UnityEngine;
using NWR.Modules;

namespace NWR.Lobby
{
    public class UI_ChooseGameModeItem : MonoBehaviour, I_UI_ItemChooser
    {
        [Header("Info:")]
        [ReadOnly, SerializeField] public GameMode gameModeToChoose;

        public void ChooseThisItem()
        {
            Player.Instance.selectedGameModeID = gameModeToChoose.GetID();
        }
    }
}