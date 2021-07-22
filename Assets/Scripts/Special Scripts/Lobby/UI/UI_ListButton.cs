using UnityEngine;

namespace NWR.Lobby
{
    public class UI_ListButton : MonoBehaviour
    {
        [Header("Params: ")]
        [SerializeField] private string listGameObject_Name;
        [SerializeField] private Vector2 listPosition_ON_screen;
        [SerializeField] private Vector2 listPosition_OUT_ofScreen;

        [Space(10)]
        [SerializeField] private Vector2 leap;
        [Header("Info box:")]
        [ReadOnly] private bool isActive;

        // ! Very important add examination if list found or not
        void Start()
        {
            FindListGameObject();
        }

        private void FindListGameObject()
        {
            //GameObject listGameObject = this.gameObject.transform.parent.GetChild(0).gameObject;
            //GameObject listGameObject = this.gameObject.transform.parent.FindChild(listGameObject_Name).gameObject;

            // if (listGameObject == null)
            // {
            //     Debug.LogError("List Button doesn't found list gameObject");
            // }
        }
        public void ShowList()
        {
            this.gameObject.transform.parent.GetChild(0).gameObject.GetComponent<IShowOrHideList>().ShowOrHide();
        }
    }
}
