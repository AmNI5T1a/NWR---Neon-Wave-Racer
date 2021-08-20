using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static GameSettings Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }
}
