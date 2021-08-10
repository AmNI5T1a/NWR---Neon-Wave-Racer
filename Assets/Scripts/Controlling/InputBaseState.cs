using UnityEngine;

namespace NWR.Modules
{
    public abstract class InputBaseState : MonoBehaviour
    {
        protected string inputDescription;
        public abstract void Stop();
        public abstract void Start();
        public abstract void MonitorInput();

        public string GetDescription => inputDescription;
    }
}