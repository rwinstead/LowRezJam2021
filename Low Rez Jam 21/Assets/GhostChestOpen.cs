using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostChestOpen : MonoBehaviour
{
    bool playerInsideTrigger = false;
    bool chestOpened = false;
    Animator anim;


    private void Update()
    {
        if (Input.GetButtonDown("Interact") && playerInsideTrigger && !chestOpened)
        {
            anim.SetTrigger("OpenChest");
            chestOpened = true;
        }
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInsideTrigger = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInsideTrigger = false;
        }
    }
}
