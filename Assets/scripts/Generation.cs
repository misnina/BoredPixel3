using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Generation : MonoBehaviour
{
    public Tilemap tilemap;
    public GameObject[] level1;
    public GameObject[] level2;
    public GameObject[] level3;
    public int width;
    public int height;

    private void Awake()
    {
        RenderMap(GenerateArray(width, height), tilemap, level1, level2, level3);
    }


    public static int[,] GenerateArray(int width, int height)
    {
        int[,] map = new int[width, height];
        for (int x = 0; x < map.GetUpperBound(0); x++)
        {
            for (int y = 0; y < map.GetUpperBound(1); y++)
            {
                bool empty = Random.value > 0.75f;
                if (empty)
                {
                    map[x, y] = 0;
                }
                else
                {
                    map[x, y] = 1;
                }
            }
        }

        return map;
    }

    public static void RenderMap(int[,] map, Tilemap tilemmap, GameObject[] level1, GameObject[] level2, GameObject[] level3)
    {
        for (int x = 0; x < map.GetUpperBound(0); x++)
        {
            for (int y = 0; y < map.GetUpperBound(1); y++) {
                if (map[x,y] == 1)
                {
                    if (y <= ((map.GetUpperBound(1)) / 3) * 1)
                    {
                        int rand = Random.Range(0, level3.Length);
                        GameObject newTile = Instantiate(level3[rand], new Vector3(x - 0.5f, y - 0.5f, 0), Quaternion.identity, tilemmap.transform);
                        newTile.name = level3[rand].name;

                    } else if (y <= ((map.GetUpperBound(1)) / 3) * 2)
                    {

                        int rand = Random.Range(0, level2.Length);
                        GameObject newTile = Instantiate(level2[rand], new Vector3(x - 0.5f, y - 0.5f, 0), Quaternion.identity, tilemmap.transform);
                        newTile.name = level2[rand].name;

                    } else
                    {
                        int rand = Random.Range(0, level1.Length);
                        GameObject newTile = Instantiate(level1[rand], new Vector3(x - 0.5f, y - 0.5f, 0), Quaternion.identity, tilemmap.transform);
                        newTile.name = level1[rand].name;
                    }

                    
                }
            }
        }
    }
}
