using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInput : MonoBehaviour
{
    public MovementController controller;

    public float runSpeed = 30f;

    float horizontalMove = 0f;

    bool jump = false;

    public bool canMove = true;

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

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
            }
        }

        else
        {
            horizontalMove = 0f;
        }

    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.deltaTime, false, jump);
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
