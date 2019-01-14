using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Generation : MonoBehaviour
{
    public Tilemap tilemap;
    public GameObject[] tiles;
    public int width;
    public int height;

    private void Awake()
    {
        RenderMap(GenerateArray(width, height), tilemap, tiles);
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

    public static void RenderMap(int[,] map, Tilemap tilemmap, GameObject[] tiles)
    {
        for (int x = 0; x < map.GetUpperBound(0); x++)
        {
            for (int y = 0; y < map.GetUpperBound(1); y++) {
                if (map[x,y] == 1)
                {
                    int rand = Random.Range(0, tiles.Length);
                    GameObject newTile = Instantiate(tiles[rand], new Vector3(x - 0.5f, y - 0.5f, 0), Quaternion.identity, tilemmap.transform);
                    newTile.name = tiles[rand].name;
                }
            }
        }
    }
}
