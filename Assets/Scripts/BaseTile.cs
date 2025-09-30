using System;
using UnityEngine;

public class BaseTile : MonoBehaviour
{
    [SerializeField] private Vector2Int position;
    public void Initialize(Vector2Int position)
    {
        this.position = position;

        gameObject.name = String.Format("X{0} : Y{1}", this.position.x, this.position.y);
    }
}
