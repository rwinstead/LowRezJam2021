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

    Transform player;

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
            player.position = insideCathedral.position;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && blueOrb && yellowOrb && greenOrb)
        {
            player = collision.gameObject.transform;
            canEnter = true;
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
