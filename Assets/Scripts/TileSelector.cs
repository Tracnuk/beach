using UnityEngine;

public class TileSelector : MonoBehaviour
{
    [SerializeField] private LayerMask tileLayer;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f, tileLayer))
        {
            
        }
    }
}
