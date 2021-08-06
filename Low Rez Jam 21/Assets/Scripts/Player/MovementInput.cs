using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInput : MonoBehaviour
{
    public MovementController controller;

    public float runSpeed = 30f;

    float horizontalMove = 0f;

    public float climbSpeed = 20f;

    float verticalMove = 0f;

    bool jump = false;

    public bool canMove = true;

    public Animator anim;

    private void Start()
    {
        SpellAnimationCallback.spellEnded += EnableMove;
        SpellAnimationCallback.spellStarted += DisableMove;
    }

    private void OnDestroy()
    {
        SpellAnimationCallback.spellEnded -= EnableMove;
        SpellAnimationCallback.spellStarted -= DisableMove;
    }


    void Update()
    {
        if (canMove)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            
            verticalMove = Input.GetAxisRaw("Vertical") * climbSpeed;

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
            }
        }

        else
        {
            horizontalMove = 0f;
            
            verticalMove = 0f;
        }


        if (horizontalMove > 0.01f || horizontalMove < -0.01f)
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }

    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.deltaTime, verticalMove * Time.deltaTime, false, jump);
        jump = false;
    }

    private void EnableMove()
    {
        canMove = true;
    }

    private void DisableMove()
    {
        canMove = false;
    }

}
