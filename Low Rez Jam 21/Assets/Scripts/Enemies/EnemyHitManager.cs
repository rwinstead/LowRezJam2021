using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyHitManager : MonoBehaviour
{

    public int maxHealth = 1;
    public int currentHealth;

    public bool isFrozen = false;

    public SpriteRenderer spriteRend;
    public ParticleSystem deathParticles;

    private void Start()
    {

        currentHealth = maxHealth;
    }

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;

        if(currentHealth <= 0)
        {
           StartCoroutine("Die");
        }

        StartCoroutine("FlashRed");

    }

    public void FreezeEnemy()
    {
        isFrozen = true;
        //Debug.Log("I am froezn now");
    }

    public IEnumerator Die()
    {
        deathParticles.Play();
        spriteRend.color = new Color(0,0,0, 1);
        yield return new WaitForSeconds(.25f);
        Destroy(gameObject);
    }

    public IEnumerator FlashRed()
    {
        Color currColor = spriteRend.color;
        spriteRend.color = new Color(0.992f, 0.050f, 0.211f, 1);
        yield return new WaitForSeconds(.075f);
        spriteRend.color = currColor;
    }
}
