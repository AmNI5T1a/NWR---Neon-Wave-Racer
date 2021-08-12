using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace NWR.Modules
{
    public class TouchInput_LeftTurn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            VirtualInputManager.Instance.MoveLeft = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            VirtualInputManager.Instance.MoveLeft = false;
        }
    }
}
