using UnityEngine;

namespace NWR.Modules
{
    public abstract class InputBaseState : MonoBehaviour
    {
        public abstract void Stop();
        public abstract void Start();
        public abstract void MonitorInput();
    }
}