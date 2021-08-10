using UnityEngine;
using NWR.Modules;

namespace NWR.MainMenu
{
    public class UI_Main : MonoBehaviour
    {
        private void Start()
        {
            this.gameObject.GetComponent<UI_HideShow>().Show(0);
        }

        public void LoadLobby(int lobbyID)
        {
            LevelLoader.Instance.LoadScene(lobbyID);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
