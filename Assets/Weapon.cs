using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;
    
    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("Player");
        bool isGunEquipped= player.GetComponent<PlayerMovement>().gun_equipped;
        if (Input.GetButtonDown("Fire2") && isGunEquipped)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
    }
}
