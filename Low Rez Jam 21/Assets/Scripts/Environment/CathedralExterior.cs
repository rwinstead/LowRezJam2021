using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CathedralExterior : MonoBehaviour
{
    public GameObject BlueOrb;
    public GameObject YellowOrb;
    public GameObject GreenOrb;

    public GameObject openDoor;

    public Transform insideCathedral;

    bool blueOrb = false;
    bool yellowOrb = false;
    bool greenOrb = false;

    bool canEnter = false;

    public static Action bossArenaTeleport;

    private Transform player;

    void Start()
    {
        Spellcasting.activateRune += ActivateOrb;
    }

    private void OnDestroy()
    {
        Spellcasting.activateRune -= ActivateOrb;
    }

    private void Update()
    {
        if (Input.GetKeyDown("f") && canEnter)
        {
            bossArenaTeleport?.Invoke();
            player.position = insideCathedral.position;
            canEnter = false;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && blueOrb && yellowOrb && greenOrb)
        {
            player = collision.gameObject.transform;
            canEnter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && blueOrb && yellowOrb && greenOrb)
        {
            canEnter = false;
        }
    }

    void ActivateOrb(int rune)
    {

        if(rune == 1)
        {
            blueOrb = true;
            BlueOrb.SetActive(true);
        }
        if (rune == 2)
        {
            yellowOrb = true;
            YellowOrb.SetActive(true);
        }

        if (rune == 3)
        {
            greenOrb = true;
            GreenOrb.SetActive(true);
        }

        if (blueOrb && yellowOrb && greenOrb)
        {
            openDoor.SetActive(true);
        }
    }
}
