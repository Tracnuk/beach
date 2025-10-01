using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class InputManager : MonoBehaviour
{
    private Camera camera;

    [Header("Params")]
    public LayerMask playerMask;
    public LayerMask groundMask;

    [Header("Debug")]
    [SerializeField] private PlayerObject player;

    private void Awake()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!player)
            {
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, 100f, playerMask))
                {
                    player = hit.collider.gameObject.GetComponent<PlayerObject>();
                    player.Select();
                }
            }
            else
            {
;               Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, 100f, groundMask))
                {
                    BaseTile tile = hit.collider.gameObject.GetComponent<BaseTile>();
                    player.Move(tile);
                }
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            if (player)
            {
                player.Diselect();
                player = null;
            }
        }
    }
}
