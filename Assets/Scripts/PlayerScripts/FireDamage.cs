using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamage : MonoBehaviour
{
    public GameObject baloonWeapon;
    public float damage = 10f;
    public float range = 10f;

    void Update()
    {
        if (baloonWeapon.gameObject.activeSelf)
        {
            RaycastHit[] hits;
            hits = Physics.RaycastAll(transform.position, transform.forward, range);
            for(int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit = hits[i];
                HealthEnemy enemyHealth = hit.collider.GetComponent<HealthEnemy>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damage);
                }
            }
        }
    }
}
