
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

        public ShowHideAnimations(GameObject gameObjectToAnimate, Vector2 position_ON_Screen, Vector2 position_OUT_ofScreen, Vector2 leap)
        {
            this.objectToAnimate = gameObjectToAnimate;
            this.position_ON_Screen = position_ON_Screen;
            this.position_OUT_ofScreen = position_OUT_ofScreen;
            this.leap = leap;
        }

        public Sequence sequence;
        private static void KillSequence(Sequence instance)
        {
            instance.Kill();
        }
        public IEnumerator ShowAnimation()
        {
            sequence = DOTween.Sequence();

            // ? Should i move logic turn on/off interactability to root script
            if (this.objectToAnimate.GetComponent<CanvasGroup>() != null)
                this.objectToAnimate.GetComponent<CanvasGroup>().interactable = true;
            RectTransform rectTransform = this.objectToAnimate.GetComponent<RectTransform>();

            sequence.Append(rectTransform.DOAnchorPos(position_ON_Screen - leap, 0.35f));
            sequence.Append(rectTransform.DOAnchorPos(position_ON_Screen, 0.15f));
            yield return new WaitForSeconds(1.05f);

            sequence.AppendCallback(() => { KillSequence(sequence); });
        }

        public IEnumerator HideAnimation()
        {
            sequence = DOTween.Sequence();

            // ? Should i move logic turn on/off interactability to root script
            if (this.objectToAnimate.GetComponent<CanvasGroup>() != null)
                this.objectToAnimate.GetComponent<CanvasGroup>().interactable = false;
            RectTransform rectTransform = this.objectToAnimate.GetComponent<RectTransform>();

            sequence.Append(rectTransform.DOAnchorPos(position_ON_Screen - leap, 0.15f));
            sequence.Append(rectTransform.DOAnchorPos(position_OUT_ofScreen, 0.35f));
            yield return new WaitForSeconds(1.05f);

            sequence.AppendCallback(() => { KillSequence(sequence); });
        }
    }
}