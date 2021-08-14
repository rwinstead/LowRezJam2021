using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaKilPlayerlOnTouch : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Health>().takeDamage(6);
        }
    }

}
