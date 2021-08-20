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

            Assets.OnSendPlayerSelectedItems += SetAndInstanciatePlayerCarAtStart;
        }

        public void SetAndInstanciatePlayerCarAtStart(object sender, Assets.PlayerSelectedItemsEventArgs e)
        {
            playerCarGameObject = Instantiate(e.playerCar.item.GetCarAsGameObject(), playerCarPosition, Quaternion.identity);
            playerCar = e.playerCar.item;
        }

        public void UpdatePlayerCar(Car newCar)
        {
            if (playerCarGameObject != null)
                Destroy(playerCarGameObject);

            playerCar = newCar;
            playerCarGameObject = Instantiate(playerCar.GetCarAsGameObject(), playerCarPosition, Quaternion.identity);
            playerCarGameObject.SetActive(true);
        }

        private void OnDestroy()
        {
            Assets.OnSendPlayerSelectedItems -= SetAndInstanciatePlayerCarAtStart;
        }
    }
}
