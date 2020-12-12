﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Add the TextMesh Pro namespace to access the various functions.


public class RenderWeapons : MonoBehaviour
{
    void Start()
    {
        GameObject weaponTemplate = transform.GetChild(0).gameObject;
        GameObject weaponsManager = GameObject.Find("WeaponsManager");

        Weapon[] weapons = FindObjectOfType<WeaponsManager>().weapons;

        GameObject g;

        foreach (var weapon in weapons)
        {
            g = Instantiate(weaponTemplate, transform);
            GameObject gButton = g.transform.GetChild(0).gameObject;
            GameObject gImage = gButton.transform.GetChild(0).gameObject;
            gImage.GetComponent<Image>().sprite = weapon.assetImage;
            GameObject gName = gImage.transform.GetChild(0).gameObject;
            GameObject gDesc = gImage.transform.GetChild(1).gameObject;
            gName.GetComponent<TMPro.TextMeshProUGUI>().text = weapon.name;
            gDesc.GetComponent<TMPro.TextMeshProUGUI>().text = weapon.description;


            GameObject elixirManager = GameObject.Find("ElixirManager");
            var elixirDict = elixirManager.GetComponent<ElixirSystem>().getElixirString();
            GameObject gElixirCost = gButton.transform.GetChild(1).gameObject;

            int[] costs = new int[] { weapon.fireElixir, weapon.waterElixir, weapon.ironElixir, weapon.earthElixir };
            for (int i = 0; i <4; i++)
            {
                GameObject gCost = gElixirCost.transform.GetChild(i).gameObject;
                GameObject gCostText = gCost.transform.GetChild(0).gameObject;
                gCostText.GetComponent<TMPro.TextMeshProUGUI>().text = costs[i].ToString();

            }
            

        }

        Destroy(weaponTemplate);
    }
}