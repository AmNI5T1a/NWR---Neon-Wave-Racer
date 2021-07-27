using System.Collections.Generic;
using NWR.Lobby;
using UnityEngine;
using System.Linq;

namespace NWR.Modules
{
    [CreateAssetMenu(fileName = "Car", menuName = "NWR/Items/Car")]
    public class Car : Item, IBuyable
    {
        [SerializeField] private uint price;
        [SerializeField] private string description;
        [SerializeField] private GameObject prefab;



        public uint GetPrice() => price;
        public GameObject GetCarAsGameObject() => prefab;
        public void Buy()
        {
            throw new System.NotImplementedException();
        }
    }
}
