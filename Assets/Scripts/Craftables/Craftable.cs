using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Craftable
{
    //Elixir costs
    public int fireElixir;
    public int waterElixir;
    public int earthElixir;
    public int ironElixir;
    public int basmiumElixir;
    public int lightningElixir;
    public int azureElixir;

    //Display info
    public string name;
    public string description;
    public Sprite assetImage;

    //Function to get ordered list of Elixir Costs
    public int[] getElixirCosts()
    {
        int[] elixirCosts = new int[] { fireElixir, waterElixir, ironElixir, earthElixir, basmiumElixir, lightningElixir, azureElixir };
        return elixirCosts;
    }
}

