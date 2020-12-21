using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Add the TextMesh Pro namespace to access the various functions.


public class RenderTools : MonoBehaviour
{
    void Start()
    {
        GameObject toolTemplate = transform.GetChild(0).gameObject;
        Tool[] tools = FindObjectOfType<ToolsManager>().tools;

        //Get elixir values 
        GameObject elixirManager = GameObject.Find("ElixirManager");
        int[] elixirsArray = elixirManager.GetComponent<ElixirSystem>().getElixirOrdered();

        GameObject g;
        foreach (var tool in tools)
        {
            g = Instantiate(toolTemplate, transform);
            GameObject gButton = g.transform.GetChild(0).gameObject;
            GameObject gImage = gButton.transform.GetChild(0).gameObject;
            gImage.GetComponent<Image>().sprite = tool.assetImage;
            GameObject gName = gImage.transform.GetChild(0).gameObject;
            GameObject gDesc = gImage.transform.GetChild(1).gameObject;
            gName.GetComponent<TMPro.TextMeshProUGUI>().text = tool.name;
            gDesc.GetComponent<TMPro.TextMeshProUGUI>().text = "Hell";
            GameObject gElixirCost = gButton.transform.GetChild(1).gameObject;

            int[] costs = tool.getElixirCosts();
            bool canCraft = true;
            for (int i = 0; i < 4; i++)
            {
                GameObject gCost = gElixirCost.transform.GetChild(i).gameObject;
                GameObject gCostText = gCost.transform.GetChild(0).gameObject;
                gCostText.GetComponent<TMPro.TextMeshProUGUI>().text = costs[i].ToString();
                if (costs[i] > elixirsArray[i])
                {
                    canCraft = false;
                    gCostText.GetComponent<TMPro.TextMeshProUGUI>().color = new Color32(255, 0, 0, 255);
                }
            }

            gButton.GetComponent<Button>().onClick.AddListener(delegate ()
            {
                //Debug.Log("Clicked " + weapon.name);
                if (canCraft)
                {
                    GameObject inventoryManager = GameObject.Find("InventoryManager");
                    inventoryManager.GetComponent<InventoryManager>().addTool(tool);
                }
                else
                {
                    Debug.Log("Can't Craft");
                }
            });
        }

        Destroy(toolTemplate);
    }
}
