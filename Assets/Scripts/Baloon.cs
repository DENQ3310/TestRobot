using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloonActivate : MonoBehaviour
{
    public GameObject BaloonWeapon;
    public GameObject teslaWeapon;
    void OnTriggerEnter (Collider other)
    {
        if (other.name == "Body1") {
            teslaWeapon.gameObject.SetActive(false);
            BaloonWeapon.gameObject.SetActive(true);
        }
    }
}
