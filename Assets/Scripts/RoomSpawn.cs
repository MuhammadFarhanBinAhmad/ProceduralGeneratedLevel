using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawn : MonoBehaviour
{

    RoomManager the_RM;

    public enum r_Direction_Enum
    {
        LEFT,RIGHT,TOP,DOWN
    }
    public r_Direction_Enum r_Dir;

    private void Start()
    {
        the_RM = FindObjectOfType<RoomManager>();
        the_RM.spawn_Point.Add(this);
        //SpawnRoom();
    }
    public void SpawnRoom()
    {
        if (the_RM.r_To_Spawn > 0)
        {
            Vector3 n_Spawn_Dir = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            switch (r_Dir)
            {
                case r_Direction_Enum.DOWN:
                    {
                        Instantiate(the_RM.D_To_Spawn_Room[Random.Range(0, the_RM.D_To_Spawn_Room.Count)], n_Spawn_Dir, Quaternion.identity);
                        break;
                    }
                case r_Direction_Enum.TOP:
                    {
                        Instantiate(the_RM.T_To_Spawn_Room[Random.Range(0, the_RM.T_To_Spawn_Room.Count)], n_Spawn_Dir, Quaternion.identity);
                        break;
                    }
                case r_Direction_Enum.LEFT:
                    {
                        Instantiate(the_RM.L_To_Spawn_Room[Random.Range(0, the_RM.L_To_Spawn_Room.Count)], n_Spawn_Dir, Quaternion.identity);
                        break;
                    }
                case r_Direction_Enum.RIGHT:
                    {
                        Instantiate(the_RM.R_To_Spawn_Room[Random.Range(0, the_RM.R_To_Spawn_Room.Count)], n_Spawn_Dir, Quaternion.identity);
                        break;
                    }
            }
            the_RM.spawn_Point.Remove(this);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Room")
        {
            print("Hit");
            the_RM.spawn_Point.Remove(this);
            Destroy(gameObject);
        }
    }
}
