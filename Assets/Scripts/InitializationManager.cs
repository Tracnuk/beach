using UnityEngine;

public class InitializationManager : MonoBehaviour
{
    private void Start()
    {
        MapManager.Instance.Initialize();
        ObjectManager.Instance.Initialize();
    }
}
