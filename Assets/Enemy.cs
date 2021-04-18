using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 0.0001f;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    private Vector3 startingPosition;
    public float pingpong_length;
    public bool pingpong_xy;
    public int pingpong_dir;
    public bool pingpong_circle;
    public float RotateSpeed;
    private float _angle;
    public float Radius;
    public float pingpong_speed;
    // Start is called before the first frame update
    void Start()
    {
        //rb.velocity = -1 * transform.right * speed;
        startingPosition = transform.position; 
        
    }
    void Update()
    {
        if (pingpong_circle)
        {
            _angle += RotateSpeed * Time.deltaTime;

            var offset = new Vector3(Mathf.Sin(_angle), Mathf.Cos(_angle),0) * Radius;
            transform.position = startingPosition + offset;
        }
        else {
            if (pingpong_xy)
                transform.position = new Vector3(startingPosition.x, startingPosition.y + Mathf.PingPong(Time.time, pingpong_length) * pingpong_speed * pingpong_dir, startingPosition.z);
            else
                transform.position = new Vector3(startingPosition.x + Mathf.PingPong(Time.time, pingpong_length) * pingpong_speed * pingpong_dir, startingPosition.y, startingPosition.z);
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision);
        GameObject x = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(x, x.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }


}
