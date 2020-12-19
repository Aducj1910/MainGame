using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<Weapon> inventoryWeapons;

    public static Weapon currentWeapon = new Weapon();

    public void addWeapon(Weapon w)
    {
        inventoryWeapons.Add(w);
    }

    public List<Weapon> getWeapons()
    {
         return inventoryWeapons;
    }

    public void setCurrentWeapon(Weapon weap)
    {
        currentWeapon = weap;
        Debug.Log(weap.name);
    }

    public Weapon getCurrentWeapon()
    {
        return currentWeapon;
    }
}
