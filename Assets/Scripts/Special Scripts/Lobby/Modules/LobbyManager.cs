using UnityEngine;
using NWR.Modules;

namespace NWR.Lobby
{
    public class LobbyManager : MonoBehaviour
    {
        public static LobbyManager Instance;

        [Header("Stats: ")]
        [SerializeField] public Vector3 playerCarPosition;

        [Header("Info box: ")]
        [ReadOnly, SerializeField] public Car playerCar;
        [ReadOnly, SerializeField] public GameObject playerCarGameObject;


        void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this.gameObject);

            Assets.OnSendPlayerSelectedItems += SetAndInstanciatePlayerCar;
        }

        public void SetAndInstanciatePlayerCar(object sender, Assets.OnSendPlayerSelectedItemsEventArgs e)
        {
            playerCarGameObject = Instantiate(e.playerCar.item.GetCarAsGameObject(), playerCarPosition, Quaternion.identity);
            playerCar = e.playerCar.item;
        }

        private void OnDestroy()
        {
            Assets.OnSendPlayerSelectedItems -= SetAndInstanciatePlayerCar;
        }
    }
}
