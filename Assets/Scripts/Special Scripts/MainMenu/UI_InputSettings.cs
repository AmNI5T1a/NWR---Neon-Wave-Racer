using UnityEngine;
using NWR.Modules;

namespace NWR.MainMenu
{
    public class UI_InputSettings : MonoBehaviour
    {
        // TODO: 2 functions 
        // TODO: One for switch to keyboard
        // TODO: One for switch to touch
        public void SwitchToKeyboardInput()
        {
            InputManager.Instance.SwitchInputLayout<KeyboardInput>();
        }

        public void SwitchToTouchInput()
        {
            InputManager.Instance.SwitchInputLayout<TouchInput>();
        }
    }
}