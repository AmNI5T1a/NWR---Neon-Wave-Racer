using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace NWR.Modules
{
    public class TouchInput_Brake : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            VirtualInputManager.Instance.Brake = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            VirtualInputManager.Instance.Brake = false;
        }
    }
}
