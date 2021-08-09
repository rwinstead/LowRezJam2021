using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpenTrigger : MonoBehaviour
{

    bool playerInsideTrigger = false;
    Animator anim;

    private void Update()
    {
        if(Input.GetKeyDown("f") && playerInsideTrigger)
        {
            anim.SetTrigger("OpenChest");
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
