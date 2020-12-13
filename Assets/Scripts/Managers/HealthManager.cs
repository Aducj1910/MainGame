using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public GameObject healthBar;
    void Start()
    {
        healthBar.GetComponent<HealthBar>().HealthBarSetup(100);
    }
}
