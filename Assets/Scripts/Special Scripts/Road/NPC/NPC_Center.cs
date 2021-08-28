using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NWR.PlayingMode
{
    public class NPC_Center : MonoBehaviour, IGetCenterPosition
    {
        [SerializeField] Vector3 _centerPosition;
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            _centerPosition = this.gameObject.transform.position;
        }

        public Vector3 GetCenterPosition() => _centerPosition;
    }
}