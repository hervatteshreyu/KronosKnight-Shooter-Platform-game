using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    // Start is called before the first frame update
    [SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
    [SerializeField] private Transform m_GroundCheck;
    const float k_GroundedRadius = .02f;
    private bool m_Grounded;
    public Animator animator;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    //int jump = 0;
    int jump_cnt = 0;
    bool jump = false;
    bool crouch = false;
    public bool gun_equipped = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("speed",Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Fire1"))
        {
            if (gun_equipped) {
                gun_equipped = false;
                animator.SetBool("isGun", false);
            }
            else
            {
                gun_equipped = true;
                animator.SetBool("isGun", true);
            }
            
        }
        if (Input.GetButtonDown("Jump"))
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
