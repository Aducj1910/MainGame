using CodeMonkey.Utils;
using System.Collections;
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

    public bool inventoryActive;

    void Awake()
    {
        itemSlotContainer = transform.Find("ItemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("ItemSlotTemplate");
    }

    void Start()
    {
        inventoryManager = GameObject.Find("InventoryManager");
    }

    public void refreshInventorySlots()
    {
        int x = 0;
        int y = 0;
        float itemSlotCellSize = 100f;
        weapons = inventoryManager.GetComponent<InventoryManager>().getWeapons();

        if (weapons != null)
        {
            foreach (var weapon in weapons)
            {
                RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
                itemSlotRectTransform.gameObject.SetActive(true);
                itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);

                itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () =>
                {
                    inventoryManager.GetComponent<InventoryManager>().setCurrentWeapon(weapon);
                };

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
