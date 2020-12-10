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
    public int probability;

    public HashSet<Vector2> shiningTiles = new HashSet<Vector2>();
    //public List<Dictionary<string, float>> shiningUsedTilesArray = new List<Dictionary<string, float>>();

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
                    int passerNumber = Random.Range(1, probability + 1); //change this number to change spawn probability
                    int dividedNumber = passerNumber / probability;
                    if(dividedNumber == 1)
                    {
                        TilemapShining.SetTile(myPos, animatedTile);
                        shiningTiles.Add(new Vector2(wid, hei));
                    }
                }
            }
        }
    }

    //public void destroyShiningTile(float x, float y)
    //{
    //    Dictionary<string, float> Coordinates = new Dictionary<string, float>();
    //    Coordinates.Add("x", x);
    //    Coordinates.Add("y", y);

    //    shiningUsedTilesArray.Add(Coordinates);
    //}

    public HashSet<Vector2> getShiningTiles()
    {
        return shiningTiles;
    }

    public void removeShiningTileAt(Vector2 coords)
    {
        shiningTiles.Remove(coords);
        var tilePos = new Vector3Int((int)(coords[0] - 0.5f), (int)(coords[1] - 0.5f), 0);
        TilemapShining.SetTile(tilePos, null);
    }

    //public List<Dictionary<string, float>> sendShiningUsedTilesArray()
    //{
    //    return shiningUsedTilesArray;
    //}
}

