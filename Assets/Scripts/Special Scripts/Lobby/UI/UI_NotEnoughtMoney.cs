using System.Collections;
using NWR.Modules;
using UnityEngine;


namespace NWR.Lobby
{
    public class UI_NotEnoughtMoney : MonoBehaviour
    {
        [Header("Stats:")]
        [SerializeField] private float timeOnScreen = 0.7f;

        [SerializeField] private Vector2 position_ON_Screen;
        [SerializeField] private Vector2 position_OUT_Screen;

        [SerializeField] private Vector2 leap;

        [Header("Info: ")]
        [ReadOnly, SerializeField] private GameObject notificationWindow;

        public void ShowNotificationWindow(ref GameObject instance)
        {
            this.notificationWindow = instance;
            StartCoroutine(PopUpNotificationWindow());
        }
        private IEnumerator PopUpNotificationWindow()
        {
            ShowHideAnimations animations = new ShowHideAnimations(gameObjectToAnimate: notificationWindow,
                                                                    position_ON_Screen: position_ON_Screen,
                                                                    position_OUT_ofScreen: position_OUT_Screen,
                                                                    leap: leap);

            StartCoroutine(animations.ShowAnimation());
            yield return new WaitForSeconds(timeOnScreen);
            StartCoroutine(animations.HideAnimation());
            yield return new WaitUntil(() => !animations.sequence.active);
            Destroy(notificationWindow);
        }
    }
}