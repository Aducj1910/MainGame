﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private List<Weapon> weapons;
    private GameObject inventoryManager;
    private Component invManager;

    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;

    void Awake()
    {
        itemSlotContainer = transform.Find("ItemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("ItemSlotTemplate");
    }

    void Start()
    {
        inventoryManager = GameObject.Find("InventoryManager");

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            refreshInventorySlots();
        }
    }

    private void refreshInventorySlots()
    {
        int x = 0;
        int y = 0;
        float itemSlotCellSize = 100f;
        weapons = inventoryManager.GetComponent<InventoryManager>().getWeapons();

        if (weapons.Count != 0)
        {
            foreach (var weapon in weapons)
            {
                RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
                itemSlotRectTransform.gameObject.SetActive(true);
                itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
                Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
                image.sprite = weapon.assetImage;

                x++;
                if (x > 3)
                {
                    x = 0;
                    y--;
                }

            }
        }

    }
    
}
