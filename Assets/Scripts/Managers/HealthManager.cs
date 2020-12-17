using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public GameObject healthBar;
    [HideInInspector] public static int health;

    void Start()
    {
        health = 100;
        healthBar.GetComponent<HealthBar>().HealthBarSetup(100);
    }

    public void updateHealth(int healthChange)
    {
        health = health + healthChange;
        healthBar.GetComponent<HealthBar>().SetHealth(health);
    }
}
