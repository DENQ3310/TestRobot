using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TeslaActivate : MonoBehaviour
{
    public GameObject teslaWeapon;
    public GameObject BaloonWeapon;
    void OnTriggerEnter (Collider other)
    {
        if (other.name == "Body1") {
            BaloonWeapon.gameObject.SetActive(false);
            teslaWeapon.gameObject.SetActive(true);
        }
    }
    
}
