using UnityEngine;

namespace NWR.Lobby
{
    public class UI_ListButton : MonoBehaviour
    {
        [Header("Params: ")]
        [SerializeField] private GameObject listGameObject;



        void Start()
        {
            ShowErrorIfListGameObjectEmpty();
        }

        private void ShowErrorIfListGameObjectEmpty()
        {
            if (listGameObject == null)
                Debug.LogError("List game object is empty");
        }

        public void ShowOrHideList()
        {
            listGameObject.GetComponent<IShowHideUIComponent>().ShowOrHideUIComponent();
        }
    }
}