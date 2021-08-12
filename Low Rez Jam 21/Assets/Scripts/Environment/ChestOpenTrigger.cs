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
    public static Action<int> chestPlayerTooltip;

    private void Update()
    {
        if(Input.GetKeyDown("f") && playerInsideTrigger && !chestOpened)
        {
            anim.SetTrigger("OpenChest");
            chestOpened = true;
            unlockRune?.Invoke(RuneID);
            chestPlayerTooltip?.Invoke(0);
            if (RuneID == 2)
            {
                chestPlayerTooltip?.Invoke(2);
            }
            if (RuneID != 2)
            {
                chestPlayerTooltip?.Invoke(3);
            }
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
            if(RuneID == 2)
            {
                chestPlayerTooltip?.Invoke(1);
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInsideTrigger = false;
                chestPlayerTooltip?.Invoke(0);
        }
    }

}
