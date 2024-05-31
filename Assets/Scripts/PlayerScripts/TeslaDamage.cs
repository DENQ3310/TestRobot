using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeslaDamage : MonoBehaviour
{
    public GameObject teslaWeapon;
    public float damage = 5f;
    public float radius = 5f;

    void Update()
    {
        if (teslaWeapon.gameObject.activeSelf)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("Enemy"))
                {
                    HealthEnemy enemyHealth = collider.GetComponent<HealthEnemy>();
                    if (enemyHealth != null)
                    {
                    enemyHealth.TakeDamage(damage);
                    }
                }   
            }
            
        }
    }
}
