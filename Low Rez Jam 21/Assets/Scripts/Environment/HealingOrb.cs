using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingOrb : MonoBehaviour
{

    Animator anim;
    private bool isUsed = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isUsed == false)
        {
            collision.gameObject.GetComponent<Health>().healDamage(2);
            anim.SetTrigger("HeartGot");
            isUsed = true;
            
        }

    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }

}
