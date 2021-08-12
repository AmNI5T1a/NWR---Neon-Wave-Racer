using UnityEngine;
using NWR.Modules;

namespace NWR.MainMenu
{
    public class UI_HideShow : MonoBehaviour
    {
        IAppearAnimation appearAnimation = new Menu_Animations();
        IHideAnimation hideAnimation = new Menu_Animations();

        public void HideThisAndShowGO_WithID_InParams(int transfromPositionObjectToShow)
        {
            StartCoroutine(hideAnimation.HideAnimation(this.gameObject));
            StartCoroutine(appearAnimation.AppearAnimation(this.gameObject.transform.root.GetChild(transfromPositionObjectToShow)?.gameObject) ??
                                                        appearAnimation.AppearAnimation(this.gameObject.transform.root.GetChild(0)?.gameObject));
        }

        public void Show(int transformPositionObjectToShow)
        {
            StartCoroutine(appearAnimation.AppearAnimation(this.gameObject.transform.parent.GetChild(transformPositionObjectToShow).gameObject));
        }
    }
}
