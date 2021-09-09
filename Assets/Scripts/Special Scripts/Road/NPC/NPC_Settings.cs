using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace NWR.PlayingMode
{
    public class NPC_Settings : MonoBehaviour, I_NPC_CarDestroyer
    {
        [SerializeField] float cooldownBetweenPossibleToDestroy = 3f;
        [SerializeField] bool possibleToDestroy = false;

        private void Start()
        {
            cooldownBetweenPossibleToDestroy -= Time.deltaTime;
            if (cooldownBetweenPossibleToDestroy <= 0)
                possibleToDestroy = true;
        }
        public void DestroyGameObject()
        {
            if (possibleToDestroy)
                Destroy(this.gameObject);
        }
    }
}
