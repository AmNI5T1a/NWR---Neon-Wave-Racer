using UnityEngine;
using NWR.Lobby;
using NWR.Modules;

namespace NWR.Modules
{
    [CreateAssetMenu(fileName = "Road", menuName = "NWR/Items/Road")]
    public class Road : Item
    {
        [SerializeField] private byte sceneToLoadID;
        [SerializeField] private uint price;
        [SerializeField] private string description;
        [SerializeField] private Sprite image;



        public void Buy()
        {
            throw new System.NotImplementedException();
        }
    }
}
