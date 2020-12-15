using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<Weapon> inventoryWeapons;

    public void addWeapon(Weapon w)
    {
        inventoryWeapons.Add(w);
    }

    public List<Weapon> getWeapons()
    {
        return inventoryWeapons;
    }
}
