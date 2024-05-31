using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageByEnemy : MonoBehaviour
{
    public int damageAmount = 10; 

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HealthPlayer playerHealth = collision.gameObject.GetComponent<HealthPlayer>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}
