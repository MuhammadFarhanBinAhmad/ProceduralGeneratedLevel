using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGenerate : MonoBehaviour
{
    public int size;
    public int x_Axis_Limit;
    int x_Axis;
    int y_Axis;

    GameObject starting_SS;

    public List<GameObject> s_SpawnShape = new List<GameObject>();
    public List<GameObject> s_Maze = new List<GameObject>();


    private void Start()
    {
        for (int i = 0; i <= size; i++)
        {
            GameObject SS;
            if (i == 0)
            {
                SS = Instantiate(s_SpawnShape[Random.Range(0, s_SpawnShape.Count)]);
                starting_SS = SS;
            }
            else
            {
                Vector3 previos_Cube_Pos = s_Maze[i - 1].transform.position;//get last cube pos
                if (x_Axis <= 4)
                {
                    Vector3 new_Cube_Pos;

                    SS = Instantiate(s_SpawnShape[Random.Range(0, s_SpawnShape.Count)]);
                    if (SS.GetComponent<Renderer>())
                    {
                        //x is center of box
                        new_Cube_Pos = new Vector3(previos_Cube_Pos.x + SS.GetComponent<Renderer>().bounds.size.x, previos_Cube_Pos.y, previos_Cube_Pos.z);//set current cube spawning pos
                    }
                    else
                    {
                        new_Cube_Pos = new Vector3(previos_Cube_Pos.x + 1, previos_Cube_Pos.y, previos_Cube_Pos.z);//set current cube spawning pos
                    }
                    SS.transform.position = new_Cube_Pos;
                    x_Axis++;
                }
                else
                {
                    y_Axis++;
                    Vector3 new_starting_SS = new Vector3(starting_SS.transform.position.x, starting_SS.transform.position.y+y_Axis, starting_SS.transform.position.z);
                    SS = Instantiate(s_SpawnShape[Random.Range(0, s_SpawnShape.Count)], new_starting_SS, Quaternion.identity);
                    x_Axis = 0;
                }
            }
            s_Maze.Add(SS);
        }
    }

}
