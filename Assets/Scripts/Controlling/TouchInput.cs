using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using NWR.Test;

namespace NWR.Modules
{
    public class TouchInput : InputBaseState
    {
        [Header("Info box")]
        [ReadOnly, SerializeField] private GameObject touchInputCanvas;
        public override void MonitorInput()
        {

        }

        public void CreateTouchUIForDriving()
        {
            if (touchInputCanvas == null)
                touchInputCanvas = Instantiate(Resources.Load("Touch Input Canvas")) as GameObject;
        }
        public override void Start()
        {
            inputDescription = "Touch Input";
        }
        public override void Stop()
        {
            Destroy(touchInputCanvas);
        }
    }
}
