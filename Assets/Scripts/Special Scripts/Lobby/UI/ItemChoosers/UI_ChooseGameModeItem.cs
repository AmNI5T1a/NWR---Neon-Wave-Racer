using UnityEngine;
using NWR.Modules;

namespace NWR.Lobby
{
    public class UI_ChooseGameModeItem : MonoBehaviour
    {
        [Header("Info:")]
        [ReadOnly, SerializeField] public GameMode gameModeToChoose;
    }
}