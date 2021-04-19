using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 0.001f;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    public bool isPlayer;
    private Vector3 startingPosition;
    void Start()
    {
        startingPosition = transform.position;
        GameObject firepoint = GameObject.Find("firepoint");
        GameObject player = GameObject.Find("Player");
        if (isPlayer)
        {
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
        else
        {
            Vector3 playerPosition = player.transform.position;
            playerPosition = (playerPosition - transform.position).normalized;
            rb.velocity = playerPosition * speed;
        }
    }

    private void Update()
    {
        if (Vector3.Distance(startingPosition, transform.position) > 1.5 && isPlayer)
        {
            Destroy(gameObject);
        }
        else if(Vector3.Distance(startingPosition, transform.position) > 2)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision);
        if (isPlayer)
        {
            if (!collision.gameObject.name.Contains("Bullet"))
            {
                GameObject x = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
                Destroy(gameObject);
                Destroy(x, x.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
            }
        }
        else
        {
            if (!collision.gameObject.name.Contains("Bullet") && !collision.gameObject.name.Contains("hell_beast"))
            {
                GameObject x = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
                Destroy(gameObject);
                Destroy(x, x.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
            }
        }
        
    }
}
