
using System.Collections;
using UnityEngine;
using DG.Tweening;

namespace NWR.Lobby
{
    public class ShowHideAnimations
    {
        private GameObject objectToAnimate;

        private Vector2 position_ON_Screen;
        private Vector2 position_OUT_ofScreen;

        private Vector2 leap;

        public ShowHideAnimations(GameObject instance, Vector2 position_ON_Screen, Vector2 position_OUT_ofScreen, Vector2 leap)
        {
            this.objectToAnimate = instance;
            this.position_ON_Screen = position_ON_Screen;
            this.position_OUT_ofScreen = position_OUT_ofScreen;
            this.leap = leap;
        }

        private Sequence _sequence;
        private static void KillSequence(Sequence instance)
        {
            instance.Kill();
        }
        public IEnumerator ShowAnimation()
        {
            _sequence = DOTween.Sequence();
            this.objectToAnimate.GetComponent<CanvasGroup>().interactable = true;
            RectTransform rectTransform = this.objectToAnimate.GetComponent<RectTransform>();

            _sequence.Append(rectTransform.DOAnchorPos(position_ON_Screen - leap, 0.35f));
            _sequence.Append(rectTransform.DOAnchorPos(position_ON_Screen, 0.15f));
            yield return new WaitForSeconds(1.05f);

            _sequence.AppendCallback(() => { KillSequence(_sequence); });
        }

        public IEnumerator HideAnimation()
        {
            _sequence = DOTween.Sequence();
            this.objectToAnimate.GetComponent<CanvasGroup>().interactable = false;
            RectTransform rectTransform = this.objectToAnimate.GetComponent<RectTransform>();

            _sequence.Append(rectTransform.DOAnchorPos(position_ON_Screen - leap, 0.15f));
            _sequence.Append(rectTransform.DOAnchorPos(position_OUT_ofScreen, 0.35f));
            yield return new WaitForSeconds(1.05f);

            _sequence.AppendCallback(() => { KillSequence(_sequence); });
        }
    }
}