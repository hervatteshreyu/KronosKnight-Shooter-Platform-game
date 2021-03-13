using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 0.001f;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    void Start()
    {
        GameObject firepoint = GameObject.Find("firepoint");
        GameObject player = GameObject.Find("Player");
        bool isFacingRight = player.GetComponent<CharacterController2D>().m_FacingRight;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        mousePosition = (mousePosition - transform.position).normalized;
        if (firepoint.transform.position.x - Camera.main.ScreenToWorldPoint(Input.mousePosition).x > 0 && !isFacingRight)
            rb.velocity = mousePosition * speed;
        else if (firepoint.transform.position.x - Camera.main.ScreenToWorldPoint(Input.mousePosition).x < 0 && isFacingRight)
            rb.velocity = mousePosition * speed;
        else
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        GameObject x = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(x, x.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        
    }
}
