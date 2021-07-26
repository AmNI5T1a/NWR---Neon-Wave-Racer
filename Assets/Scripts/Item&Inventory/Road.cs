using UnityEngine;
using NWR.Lobby;
using NWR.Modules;

namespace NWR.Modules
{
    [CreateAssetMenu(fileName = "Road", menuName = "NWR/Items/Road")]
    public class Road : Item, IBuyItem
    {
        [SerializeField] private uint price;
        [SerializeField] private string description;
        [SerializeField] private Sprite image;

        public void Buy() => Player.Instance.listOfPurchasedItemIDs.boughtRoads.Add(this.GetID());
    }
}
