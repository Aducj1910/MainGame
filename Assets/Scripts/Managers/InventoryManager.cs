using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<Weapon> inventoryWeapons;
    public List<Tool> inventoryTools;

    public static Weapon currentWeapon = new Weapon();
    public static Tool currentTool = new Tool();

    public void addWeapon(Weapon w)
    {
        inventoryWeapons.Add(w);
    }

    public void addTool(Tool t)
    {
        inventoryTools.Add(t);
    }

    public List<Weapon> getWeapons()
    {
         return inventoryWeapons;
    }

    public List<Tool> getTools()
    {
        return inventoryTools;
    }

    public void setCurrentWeapon(Weapon weap)
    {
        currentWeapon = weap;
        //Debug.Log(weap.name);
    }

    public Weapon getCurrentWeapon()
    {
        return currentWeapon;
    }

    public void setCurrentTool(Tool too)
    {
        currentTool = too;
    }

    public Tool getCurrentTool()
    {
        return currentTool;
    }
}
