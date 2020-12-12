using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElixirSystem : MonoBehaviour
{
    //standard elixirs
    public static int fireElixir = 0;
    public static int waterElixir = 0;
    public static int ironElixir = 0;
    public static int earthElixir = 0;

    //rare elixirs
    public static int basmiumElixir = 0;
    public static int lightningElixir = 0;
    public static int azureElixir = 0;

    public bool onGameScreen;

    void Update()
    {
        if (onGameScreen)
        {
            GameObject elixirDisplaySystem = GameObject.Find("ElixirDisplayManager");
            elixirDisplaySystem.GetComponent<ElixirDisplaySystemScript>().updateElixirText(fireElixir, waterElixir, ironElixir, earthElixir, basmiumElixir, lightningElixir, azureElixir);
        }
    }

    public void shiningTileTrigger()
    {
        fireElixir = fireElixir + Random.Range(0, 3);
        waterElixir = waterElixir + Random.Range(0, 3);
        ironElixir = ironElixir + Random.Range(0, 3);
        earthElixir = earthElixir + Random.Range(0, 3);
    }

    public Dictionary<string, int>[] getElixirString()
    {
        Dictionary<string, int>[] elixirArray = new Dictionary<string, int>[7];
        elixirArray[0] = new Dictionary<string, int>();
        elixirArray[1] = new Dictionary<string, int>();
        elixirArray[2] = new Dictionary<string, int>();
        elixirArray[3] = new Dictionary<string, int>();
        elixirArray[4] = new Dictionary<string, int>();
        elixirArray[5] = new Dictionary<string, int>();
        elixirArray[6] = new Dictionary<string, int>();


        elixirArray[0].Add("fire", fireElixir);
        elixirArray[1].Add("water", waterElixir);
        elixirArray[2].Add("iron", ironElixir);
        elixirArray[3].Add("earth", earthElixir);
        elixirArray[4].Add("basmium", basmiumElixir);
        elixirArray[5].Add("lightning", lightningElixir);
        elixirArray[6].Add("azure", azureElixir);

        return elixirArray;
    } 
}
