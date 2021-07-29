using System.Collections;
using NWR.Modules;
using UnityEngine;

namespace NWR.Lobby
{
    public class UI_NotEnoughtMoney : Singleton<UI_NotEnoughtMoney>
    {
        [Header("Info: ")]
        [ReadOnly, SerializeField] private GameObject notificationWindow;
        void Awake()
        {
            notificationWindow = Instantiate(Resources.Load<GameObject>("NotificationWindow (NotEnoughMoney)"), GameObject.FindGameObjectWithTag("Canvas").transform);
            this.gameObject.transform.parent = notificationWindow.transform;
        }

        public void ShowNotificationWindow(float showTime)
        {
            StartCoroutine(PopUpNotificationWindow(showTime));
        }
        private IEnumerator PopUpNotificationWindow(float showTime)
        {
            yield return new WaitForSeconds(showTime);
            Destroy(notificationWindow);
        }
    }
}