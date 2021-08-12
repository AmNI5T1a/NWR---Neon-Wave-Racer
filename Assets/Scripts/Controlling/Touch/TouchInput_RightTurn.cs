using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace NWR.Modules
{
    public class TouchInput_RightTurn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            VirtualInputManager.Instance.MoveRight = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            VirtualInputManager.Instance.MoveRight = false;
        }
    }
}
