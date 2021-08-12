using UnityEngine;


namespace NWR.Modules
{
    public class VirtualInputManager : Singleton<VirtualInputManager>
    {
        [SerializeField] public bool MoveForward;
        [SerializeField] public bool MoveBack;
        [SerializeField] public bool MoveLeft;
        [SerializeField] public bool MoveRight;
        [SerializeField] public bool Brake;
        [SerializeField] public bool C;
    }
}