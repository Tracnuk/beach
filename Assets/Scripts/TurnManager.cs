using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurnManager : MonoBehaviour
{
    public static TurnManager instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    private Queue<BaseObject> EndTurnQueue, StartTurnQueue;
    private void EndTurns()
    {
        EndTurnQueue = new Queue<BaseObject>();
        InputManager.instance.enabled = false;
        foreach (BaseTile tile in MapManager.instance.tiles)
        {
            if(tile!=null)tile.DisableOutline();
        }


        foreach (BaseObject obj in ObjectManager.instance.objects)
        {
            if (obj == null) continue;
            EndTurnQueue.Enqueue(obj);
            
        }
        EndTurnCur();

    }
    public void EndTurnCur() {
        if (EndTurnQueue.Count == 0) { 
            StartTurns();
            return;
        }
        BaseObject cur = EndTurnQueue.Dequeue();
        if (cur != null) Invoke("EndTurnCur", cur.TurnEnd());
    }
    private void StartTurns()
    {
        StartTurnQueue = new Queue<BaseObject>();
        foreach (BaseTile tile in MapManager.instance.tiles)
        {
            //
        }


        foreach (BaseObject obj in ObjectManager.instance.objects)
        {
            if (obj == null) continue;
            StartTurnQueue.Enqueue(obj);
            
        }
        StartTurnCur();

    }
    public void StartTurnCur()
    {
        if (StartTurnQueue.Count == 0)
        {
            InputManager.instance.enabled = true;
            return;
        }
        BaseObject cur = StartTurnQueue.Dequeue();
        if(cur!=null)Invoke("StartTurnCur", cur.TurnStart());
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("ending turn");
            EndTurns();
        }
    }
}

