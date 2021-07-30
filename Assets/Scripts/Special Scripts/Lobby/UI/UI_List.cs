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
        [ReadOnly, SerializeField] private bool onScreen = true;


        private ShowHideAnimations showHide_Animations;
        private Sequence _sequence;

        void Start()
        {
        }

        public void ShowOrHideUIComponent()
        {
            showHide_Animations = new ShowHideAnimations(gameObjectToAnimate: this.gameObject,
                                                        position_ON_Screen: position_ON_Screen,
                                                        position_OUT_ofScreen: position_OUT_ofScreen,
                                                        leap: leap);

            if (onScreen)
                StartCoroutine(showHide_Animations.HideAnimation());
            else
                StartCoroutine(showHide_Animations.ShowAnimation());

            onScreen = !onScreen;
        }
    }
}
