using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using NWR.Test;

namespace NWR.Modules
{
    public class TouchInput : InputBaseState
    {
        private GameObject touchInputCanvas;
        public override void MonitorInput()
        {

        }



        public void MoveFrontInput(bool status)
        {
            Debug.Log("Pressing Front Side Input");
            VirtualInputManager.Instance.MoveForward = status;
        }

        public void MoveBackInput(bool status)
        {
            Debug.Log("Pressing Back Side Input");
            VirtualInputManager.Instance.MoveBack = status;
        }

        public void MoveLeftSideInput()
        {
            Debug.Log("Pressing Left Side Input");
            //VirtualInputManager.Instance.MoveLeft = status;
        }

        public void MoveRightSideInput(bool status)
        {
            Debug.Log("Pressing Right Side Input");
            VirtualInputManager.Instance.MoveRight = status;
        }


        public void BrakesInput(bool status)
        {
            VirtualInputManager.Instance.Brake = status;
        }



        public override void Start()
        {
            touchInputCanvas = Instantiate(Resources.Load("Touch Input Canvas")) as GameObject;

            touchInputCanvas.transform.GetChild(0).gameObject.GetComponent<Button>().onClick.AddListener(delegate { TEST_SWITCH_INPUT_SERVICE.Instance.TESTFUNCTION(); });
            touchInputCanvas.transform.GetChild(1).gameObject.GetComponent<Button>().onClick.AddListener(delegate { TEST_SWITCH_INPUT_SERVICE.Instance.TESTFUNCTION(); });
            touchInputCanvas.transform.GetChild(2).gameObject.GetComponent<Button>().onClick.AddListener(delegate { TEST_SWITCH_INPUT_SERVICE.Instance.TESTFUNCTION(); });
            touchInputCanvas.transform.GetChild(3).gameObject.GetComponent<Button>().onClick.AddListener(delegate { TEST_SWITCH_INPUT_SERVICE.Instance.TESTFUNCTION(); });
        }
        private void Test()
        {
            Debug.LogWarning("Test");
        }

        public override void Stop()
        {
            Destroy(touchInputCanvas);
        }
    }
}
