using UnityEngine;

public class Tile : MonoBehaviour
{
    private int posX;
    private int posY;

    public GameObject occupiedGameobject;
    public bool inOccupied;

    public void SetPosition(int x, int y)
    {
        posX = x; posY = y;
    }

    public Vector2Int GetPosition()
    {
        return new Vector2Int(posX, posY);
    }
}