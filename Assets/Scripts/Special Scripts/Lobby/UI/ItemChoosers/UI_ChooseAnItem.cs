using UnityEngine;
using UnityEngine.UI;
using NWR.Modules;

namespace NWR.Lobby
{
    [RequireComponent(typeof(I_UI_ItemChooser))]
    public class UI_ChooseAnItem : MonoBehaviour
    {
        [Header("Info box:")]
        [ReadOnly, SerializeField] private Assets.ItemAndStats<Car> carInstance;

        public void UI_ChooseAnItemConstructor(Assets.ItemAndStats<Car> instance) => carInstance = instance;



        void Start()
        {
            Button btn = this.gameObject.transform.GetChild(1).GetComponent<Button>();
            btn.onClick.AddListener(() => ChooseThisItem(this.gameObject.GetComponent<I_UI_ItemChooser>()));
        }

        private void ChooseThisItem(I_UI_ItemChooser chooser)
        {
            chooser.ChooseThisItem(carInstance);
        }
    }
}
