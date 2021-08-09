using System.Collections;
using UnityEngine;
using NWR.Modules;

namespace NWR.Test
{
    public class TEST_SWITCH_INPUT_SERVICE : MonoBehaviour
    {
        public static TEST_SWITCH_INPUT_SERVICE Instance;
        [SerializeField, Range(0f, 2.5f)] private float timeOutBeforeSwitch;
        [SerializeField] private bool readyToChangeLayout = true;

        void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this.gameObject);
        }
        void Start()
        {
            Debug.LogWarning("Your are running TEST_SWITCH_INPUT_SERVICE test");
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.N))
            {
                StartCoroutine(SwitchToKeyboard());
            }
            if (Input.GetKey(KeyCode.M))
            {
                StartCoroutine(SwitchToTouch());
            }
        }

        private IEnumerator SwitchToKeyboard()
        {
            if (readyToChangeLayout)
            {
                readyToChangeLayout = false;
                InputManager.Instance.SwitchInputLayout<KeyboardInput>();
                yield return new WaitForSeconds(timeOutBeforeSwitch);
                readyToChangeLayout = true;
            }
        }
        private IEnumerator SwitchToTouch()
        {
            if (readyToChangeLayout)
            {
                readyToChangeLayout = false;
                InputManager.Instance.SwitchInputLayout<TouchInput>();
                yield return new WaitForSeconds(timeOutBeforeSwitch);
                readyToChangeLayout = true;
            }
        }

        public void TESTFUNCTION()
        {
            Debug.Log("Test fucntion working great");
        }
    }
}