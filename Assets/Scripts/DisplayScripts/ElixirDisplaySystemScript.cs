using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElixirDisplaySystemScript : MonoBehaviour
{
    private GameObject elixirManager;

    public Text fireText;
    public Text waterText;
    public Text ironText;
    public Text earthText;

    public void updateElixirText(int fireElixir, int waterElixir, int ironElixir, int earthElixir, int basmiumElixir, int lightningElixir, int azureElixir)
    {
        fireText.text = fireElixir.ToString();
        waterText.text = waterElixir.ToString();
        ironText.text = ironElixir.ToString();
        earthText.text = earthElixir.ToString();
    }
}
