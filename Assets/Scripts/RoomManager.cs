using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public List<GameObject> R_To_Spawn_Room = new List<GameObject>();
    public List<GameObject> D_To_Spawn_Room = new List<GameObject>();
    public List<GameObject> L_To_Spawn_Room = new List<GameObject>();
    public List<GameObject> T_To_Spawn_Room = new List<GameObject>();

    public List<RoomSpawn> spawn_Point = new List<RoomSpawn>();

    public int r_To_Spawn;

    private void Start()
    {
        InvokeRepeating("RoomCheck", 0, 1);
    }

    public void RoomCheck()
    {
        if (r_To_Spawn > 0)
        {
            spawn_Point[Random.Range(0, spawn_Point.Count)].SpawnRoom();
            r_To_Spawn--;
        }
        else
        {
            CancelInvoke();
        }
    }
}
