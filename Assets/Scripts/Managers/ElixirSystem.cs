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

        //TESTING ONLY
        if (Input.GetKeyDown(KeyCode.KeypadEnter)) //ONLY TO BE USED FOR TESTING PURPOSES, REMOVE AFTER TESTING PHASE
        {
            fireElixir = 20; waterElixir = 20; ironElixir = 20; earthElixir = 20;
        }
        //XXXXXXX
    }

    public void shiningTileTrigger()
    {
        fireElixir = fireElixir + Random.Range(0, 3);
        waterElixir = waterElixir + Random.Range(0, 3);
        ironElixir = ironElixir + Random.Range(0, 3);
        earthElixir = earthElixir + Random.Range(0, 3);
    }

    public Hashtable getElixirMapping()
    {
        Hashtable elixirMapping = new Hashtable();
        elixirMapping.Add("fire", fireElixir);
        elixirMapping.Add("water", waterElixir);
        elixirMapping.Add("iron", ironElixir);
        elixirMapping.Add("earth", earthElixir);
        elixirMapping.Add("basmium", basmiumElixir);
        elixirMapping.Add("lightning", lightningElixir);
        elixirMapping.Add("azure", azureElixir);

        return elixirMapping;
    }

    public int[] getElixirOrdered()
    {
        int[] elixirsOrdered = new int[] { fireElixir, waterElixir, ironElixir, earthElixir, basmiumElixir, lightningElixir, azureElixir};
        return elixirsOrdered;
    }
}
