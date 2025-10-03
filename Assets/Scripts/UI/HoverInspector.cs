using UnityEngine;

public class HoverInspector : MonoBehaviour
{
    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            ObjectInfo info = hit.collider.GetComponent<ObjectInfo>();
            if (info != null)
            {
                TooltipUI.Instance.Show(info.description);
                return;
            }
        }

        TooltipUI.Instance.Hide();
    }
}
