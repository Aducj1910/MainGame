using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory2 : MonoBehaviour
{
    private List<Tool> tools;
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
        tools = inventoryManager.GetComponent<InventoryManager>().getTools();

        if (tools != null)
        {
            foreach (var tool in tools)
            {
                RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
                itemSlotRectTransform.gameObject.SetActive(true);
                itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);

                itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () =>
                {
                    inventoryManager.GetComponent<InventoryManager>().setCurrentTool(tool);
                };

                Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
                image.sprite = tool.assetImage;

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
