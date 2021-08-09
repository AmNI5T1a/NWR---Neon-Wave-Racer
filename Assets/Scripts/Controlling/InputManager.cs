using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace NWR.Modules
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance;
        private InputBaseState _currentInputLayout;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this.gameObject);
        }

        private void Start()
        {
            _currentInputLayout = this.gameObject.AddComponent<KeyboardInput>();
        }

        private void Update()
        {
            _currentInputLayout.MonitorInput();
        }


        public void SwitchInputLayout<T>() where T : InputBaseState
        {
            _currentInputLayout.Stop();
            Destroy(_currentInputLayout);
            _currentInputLayout = this.gameObject.AddComponent<T>();
            _currentInputLayout.Start();
        }
    }
}