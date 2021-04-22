using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firepoint;
    public GameObject impactEffect;


    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine("attack");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void triggerTurret(bool trig)
    {
        if (trig)
            StartCoroutine("attack");
        else
            StopCoroutine("attack");
    }

    IEnumerator attack()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        yield return new WaitForSeconds(2);
        StartCoroutine("attack");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Bullet"))
        {
            GameObject x = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(x, x.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        }
    }
 }
