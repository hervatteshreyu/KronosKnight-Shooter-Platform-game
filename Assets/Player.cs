using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject impactEffect;
    public Transform self_transform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "enemy(Clone)")
        {
            GameObject x = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(self_transform.gameObject);
            Destroy(x, x.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        }
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "enemy")
        {
            GameObject x = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(x, x.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        }
    }
}
