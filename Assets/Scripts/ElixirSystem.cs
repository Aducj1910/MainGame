using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log(fireElixir);
        }
    }

    public void shiningTileTrigger()
    {
        fireElixir = fireElixir + Random.Range(0, 3);
        waterElixir = waterElixir + Random.Range(0, 3);
        ironElixir = ironElixir + Random.Range(0, 3);
        earthElixir = earthElixir + Random.Range(0, 3);
    }



}
