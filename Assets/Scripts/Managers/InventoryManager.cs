using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private static Hashtable weapons;
    private static Hashtable tools;

    public void addWeapon(Weapon w)
    {
        if (weapons.ContainsKey(w))
        {
            weapons[w] = (int)(weapons[w]) + 1;
        }
        else
        {
            weapons[w] = 1;
        }
        //Debug.Log(weapons[w]);
        //Debug.Log(w.name);
    }

    public Hashtable getWeapons()
    {
        return weapons;
    }

    InventoryManager()
    {
        weapons = new Hashtable();
        tools = new Hashtable();
    }
}
