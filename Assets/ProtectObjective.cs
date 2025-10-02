using UnityEngine;

public class ProtectObjective : BaseObject
{
    public int turnsLeft = 3, damage = 1, score = 1;

    public void Start()
    {
        OnTurnEnd.AddListener(TickDown);
        OnTurnStart.AddListener(TryComplete);
        OnTurnStart.AddListener(TryIndicateDamage);
        OnDestroy.AddListener(DeHighlight);
    }
    public void DeHighlight()
    {
        BaseTile[] tiles = MapManager.instance.Get4TilesAround(position).ToArray();
        foreach (BaseTile tile in tiles)
        {
            tile.DisableOutline();
        }
    }
    public void TickDown() { 
        //on end
        turnsLeft--;
    }
    public void TryComplete()
    {
        //on start
        if (turnsLeft == 0)
        {
            BaseTile[] tiles = MapManager.instance.Get4TilesAround(position).ToArray();
            foreach (BaseTile tile in tiles)
            {
                tile.DisableOutline();
                if (tile.isOccupied)
                {
                    tile.occupiedObject.Damage(damage);
                }
            }

            ScoreManager.instance.AddScore(score);
            Destroy();
        }
    }
    public void TryIndicateDamage() {
        //on start
        if (turnsLeft == 1) {
            BaseTile[] tiles = MapManager.instance.Get4TilesAround(position).ToArray();
            foreach (BaseTile tile in tiles) { 
                tile.EnableOutline(Color.red);
            }
        }
    }
}
