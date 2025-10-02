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
            Debug.Log("clicked");
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction);
            if (!player)
            {
                if (Physics.Raycast(ray, out RaycastHit hit, 10000f, playerMask))
                {
                    Debug.Log("player chosen");
                    player = hit.collider.gameObject.GetComponent<PlayerObject>();
                    player.Select();
                }
            }
            else
            {
                if (Physics.Raycast(ray, out RaycastHit hit, 10000f, groundMask))
                {
                    Debug.Log("tile chosen");
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
