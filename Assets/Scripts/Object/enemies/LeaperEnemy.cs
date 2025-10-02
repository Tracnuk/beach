using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class LeaperEnemy : BaseObject
{
    public int maxDistance = 3, damage = 1;
    BaseTile target;
    public void Start()
    {
        OnTurnEnd.AddListener(Attack);
        OnTurnStart.AddListener(PrepareAttack);
    }
    public BaseTile FindClosesttarget() {
        BaseTile init = MapManager.instance.GetInitializedTile(position);

        bool[,] used = new bool[MapManager.instance.mapSize.x, MapManager.instance.mapSize.y];
        Queue<BaseTile> q = new Queue<BaseTile>();
        q.Clear();
        q.Enqueue(init);
        //int depth = 0, depthCounter = 1;
        while (q.Count > 0) {
            BaseTile cur = q.Dequeue();
            used[cur.position.x, cur.position.y] = true;

            BaseTile[] tiles = MapManager.instance.Get4TilesAround(cur.position).ToArray();
            foreach (BaseTile tile in tiles) {
                if(used[tile.position.x, tile.position.y]) continue;
                q.Enqueue(tile);
                if ((cur.isOccupied || !cur.isWalkable)) continue;

                if (tile.isOccupied) {
                    if (tile.occupiedObject.CompareTag("EnemyTarget")) { 
                        return cur;
                    }
                }
                
            }

            if (q.Count == 0) {
                return cur;
            }
        }

        return init;
    }
    public void PrepareAttack() { 
        //on start

        BaseTile spot = FindClosesttarget();
        Move(spot);

        
        BaseTile[] tiles = MapManager.instance.Get4TilesAround(position).ToArray();
        bool ok = false;
        foreach (BaseTile tile in tiles)
        {
            if (tile.isOccupied)
            {
                if (tile.occupiedObject.CompareTag("EnemyTarget"))
                {
                    target = tile;
                    ok = true;
                    break;
                }
            }
        }
        if (!ok) target = null;
        else
        {
            LookAt(target);
            target.EnableOutline(Color.red);
        }
    }

    public void Attack() { 
        //on end 

        if(target==null) return;
        target.DisableOutline();
        if (target.isOccupied) { 
            target.occupiedObject.Damage(damage);
        }
    }
    
}
