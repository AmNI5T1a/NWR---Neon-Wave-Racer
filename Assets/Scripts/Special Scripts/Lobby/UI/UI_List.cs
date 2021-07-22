using System.Collections;
using UnityEngine;
using DG.Tweening;

namespace NWR.Lobby
{
    public class UI_List : MonoBehaviour, IShowHideUIComponent
    {
        [Header("Stats: ")]
        [SerializeField] private Vector2 position_ON_Screen;
        [SerializeField] private Vector2 position_OUT_ofScreen;

        [Space(10)]
        [SerializeField] private Vector2 leap;

        [Header("Play mode stats:")]
        [ReadOnly, SerializeField] private bool onScreen = false;


        private Sequence _sequence;

        void Start()
        {

        }

        public void ShowOrHideUIComponent()
        {
            ShowHideAnimations animations = new ShowHideAnimations(this.gameObject, position_ON_Screen, position_OUT_ofScreen, leap);

            if (onScreen)
            {
                StartCoroutine(animations.HideAnimation());
                onScreen = !onScreen;
            }
            else
            {
                StartCoroutine(animations.ShowAnimation());
                onScreen = !onScreen;
            }
        }
    }
}
