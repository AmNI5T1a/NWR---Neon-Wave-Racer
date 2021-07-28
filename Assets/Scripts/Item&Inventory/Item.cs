using UnityEngine;

namespace NWR.Modules
{
    public class Item : ScriptableObject
    {
        [SerializeField] protected ushort ID;
        [SerializeField] protected string Denomination;

        public ushort GetID() => ID;
        public string GetName() => Denomination;
    }
}
