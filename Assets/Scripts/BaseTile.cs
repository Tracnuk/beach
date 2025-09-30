using System;
using UnityEngine;

public class BaseTile : MonoBehaviour
{
    [SerializeField] private Vector2Int position;
    public void Initialize(Vector2Int position)
    {
        this.position = position;

        gameObject.name = String.Format("{0}:{1}", this.position.x, this.position.y);
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(0, Mathf.Sin(Time.time * 2 + ((float)position.x) / 8 + ((float)position.y) / 8)) / 200;
    }
}
