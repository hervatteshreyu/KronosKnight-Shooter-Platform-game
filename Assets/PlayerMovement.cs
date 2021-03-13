using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    // Start is called before the first frame update
    [SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
    [SerializeField] private Transform m_GroundCheck;
    const float k_GroundedRadius = .02f;
    private bool m_Grounded;
    public Animator animator;
    public bool dead = false;
    public bool respawn = true;
    public GameObject impactEffect;
    public int lives = 3;


    public float runSpeed = 40f;
    float horizontalMove = 0f;
    //int jump = 0;
    int jump_cnt = 0;
    bool jump = false;
    bool crouch = false;
    public bool gun_equipped = true;

    private void Start()
    {
        animator.SetBool("isGun", true);
    }
    // Update is called once per frame
    void Update()
    {
        if (dead == true)
        {
            if(respawn == true)
            {
                lives--;
                if (lives == 0)
                {
                    respawn = false;
                }
                GameObject x = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
                Destroy(gameObject, gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
                Destroy(x, x.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                GameObject x = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
                Destroy(gameObject, gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
                Destroy(x, x.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
                SceneManager.LoadScene(0);
            }
        }
        //Fall to death
        if(transform.position.y <= -1.0f)
        {
            dead = true;
        }
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("speed",Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetButtonDown("Jump") || Input.GetKeyDown("space"))
        {
            jump_cnt++;
            jump = true;
            animator.SetBool("isJumping", true);
            Debug.Log("jump_cnt in update : " + jump_cnt);

        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            animator.SetBool("isCrouching", true);
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            animator.SetBool("isCrouching", false);
            crouch = false;
        }
    }

    public void onLanding()
    {
        animator.SetBool("isJumping", false);
    }

    

    void FixedUpdate()
    {
        m_Grounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
            }
        }
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump, jump_cnt);
        //if(jump_cnt == 2 || m_Grounded)
            jump_cnt = 0;
        jump = false;

    }
}
