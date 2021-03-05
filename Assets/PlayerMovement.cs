using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    // Start is called before the first frame update

    public Animator animator;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
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
            jump = true;
            animator.SetBool("isJumping", true);
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
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
