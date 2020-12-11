using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideElixirDisplay : MonoBehaviour
{
    public GameObject elixirDisplay;
    bool state = false;


    public void SwitchShowHide()
    {
        state = !state;
        elixirDisplay.gameObject.SetActive(state);
    }
}
