using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 0.0001f;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    public BoxCollider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = -1 * transform.right * speed;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject x = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(x, x.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }


}
