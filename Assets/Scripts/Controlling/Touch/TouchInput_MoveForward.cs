using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace NWR.Modules
{
    public class TouchInput_MoveForward : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            VirtualInputManager.Instance.MoveForward = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            VirtualInputManager.Instance.MoveForward = false;
        }
    }
}
