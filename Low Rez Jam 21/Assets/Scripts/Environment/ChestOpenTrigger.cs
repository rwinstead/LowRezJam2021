using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpenTrigger : MonoBehaviour
{
    public int RuneID = -1;

    bool playerInsideTrigger = false;
    bool chestOpened = false;
    Animator anim;

    public static Action<int> unlockRune;

    private void Update()
    {
        if(Input.GetKeyDown("f") && playerInsideTrigger && !chestOpened)
        {
            anim.SetTrigger("OpenChest");
            chestOpened = true;
            unlockRune?.Invoke(RuneID);
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
