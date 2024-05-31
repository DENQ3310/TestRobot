using System.Collections;
using UnityEngine;

public class ActivateBaloon : MonoBehaviour
{
    public GameObject baloonWeapon;
    public GameObject fire;
    public ParticleSystem ps;

    void Start()
    {
        baloonWeapon.gameObject.SetActive(false);
    }

    void Update()
    {
        if (ps != null)
        {
            ps.Play();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                fire.SetActive(true);
                //ps.Stop();
                ps.Play();
            }else {
                fire.SetActive(false);
                ps.Stop();
            }
            
        }
    }
}
