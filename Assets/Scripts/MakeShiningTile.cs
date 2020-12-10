using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MakeShiningTile : MonoBehaviour
{
    public AnimatedTile animatedTile;
    public Tilemap TilemapBackground;
    public Tilemap TilemapShining;
    public int width;
    public int height;

    public List<Dictionary<string, float>> shiningTilesArray = new List<Dictionary<string, float>>();

    void Start()
    {
        for(int w = 0; w < width; w++)
        {
            for(int h = 0; h < height; h++)
            {
                float wid = w + 0.5f;
                float hei = h + 0.5f;

                Vector3Int myPos = new Vector3Int(w, h, 0);
                if(TilemapBackground.GetTile(myPos) != null)
                {
                    int passerNumber = Random.Range(1, 21); //change this number to change spawn probability
                    int dividedNumber = passerNumber / 20;
                    if(dividedNumber == 1)
                    {
                        TilemapShining.SetTile(myPos, animatedTile);
                        Dictionary<string, float> Coordinates = new Dictionary<string, float>();
                        Coordinates.Add("x", wid);
                        Coordinates.Add("y", hei);

                        shiningTilesArray.Add(Coordinates);
                    }
                }
            }
        }
    }

    public List<Dictionary<string, float>> sendShiningTilesArray()
    {
        return shiningTilesArray;
    }
}

