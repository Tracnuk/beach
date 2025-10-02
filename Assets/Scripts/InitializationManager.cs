using UnityEngine;

public class InitializationManager : MonoBehaviour
{
    private void Start()
    {
        MapManager.instance.Initialize();
        ObjectManager.instance.Initialize();
    }
}
