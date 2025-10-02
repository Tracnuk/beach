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
        BaseTile ans = MapManager.instance.GetInitializedTile(position); 
        
        Queue<BaseTile> q = new Queue<BaseTile>();
        q.Clear();
        q.Enqueue(ans);
        //int depth = 0, depthCounter = 1;
        while (q.Count > 0) {
            BaseTile cur = q.Dequeue();

            BaseTile[] tiles = MapManager.instance.Get4TilesAround(cur.position).ToArray();
            foreach (BaseTile tile in tiles) {
                q.Enqueue(tile);
                if (cur.isOccupied || !cur.isWalkable) continue;

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

        return MapManager.instance.GetInitializedTile(position);
    }
    public void PrepareAttack() { 
        //on start

        BaseTile spot = FindClosesttarget();
        Move(spot);

        
        BaseTile[] tiles = MapManager.instance.Get4TilesAround(position).ToArray();
        foreach (BaseTile tile in tiles)
        {
            if (tile.isOccupied)
            {
                if (tile.occupiedObject.CompareTag("EnemyTarget"))
                {
                    target = tile;
                    break;
                }
            }
        }
        
        LookAt(target);
        target.EnableOutline(Color.red);
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
