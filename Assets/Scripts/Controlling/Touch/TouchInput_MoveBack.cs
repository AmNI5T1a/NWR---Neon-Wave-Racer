using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace NWR.Modules
{
    public class TouchInput_MoveBack : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            VirtualInputManager.Instance.MoveBack = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            VirtualInputManager.Instance.MoveBack = false;
        }
    }
}
