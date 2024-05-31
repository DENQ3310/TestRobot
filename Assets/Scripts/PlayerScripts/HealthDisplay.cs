using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public HealthPlayer playerHealth; 
    public Text healthText; 

    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthPlayer>();
    }

    void Update()
    {
        healthText.text = "Health: " + playerHealth.currentHealth.ToString();
    }
}
