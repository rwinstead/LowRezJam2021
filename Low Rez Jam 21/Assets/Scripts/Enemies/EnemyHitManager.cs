using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class EnemyHitManager : MonoBehaviour
{

    public int maxHealth = 1;
    public int currentHealth;

    public bool isFrozen = false;
    public bool isBoss = false;

    public SpriteRenderer spriteRend;
    public ParticleSystem deathParticles;

    public static Action<float> bossHealthChange;
    public static Action bossDeath;

    bool dead = false;

    private void Start()
    {

        currentHealth = maxHealth;
        Health.playerRespawn += resetEnemyHealth;
    }

    private void Update()
    {
        if(currentHealth <= 0)
        {
            StartCoroutine("Die");
        }
    }

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;

        if (currentHealth <= 0 && !dead)
        {
            StartCoroutine("Die");
            dead = true;

            if (isBoss)
            {
                bossDeath?.Invoke();
            }
        }

        StartCoroutine("FlashRed");

        if (isBoss)
        {
            bossHealthChange?.Invoke((float)currentHealth / (float)maxHealth);
        }

    }

    public void Kill()
    {
        StartCoroutine("Die");
    }

    public void FreezeEnemy()
    {
        isFrozen = true;
        //Debug.Log("I am froezn now");
    }

    public void Poison()
    {
        InvokeRepeating("TakePoisonDmg", 0, 1);
        StartCoroutine("StopPoison");
    }

    void TakePoisonDmg()
    {
        StopCoroutine("DeadlPoisonDmg");
        StartCoroutine("DealPoisonDmg");
    }

    public IEnumerator DealPoisonDmg()
    {
        Color currColor = spriteRend.color;
        spriteRend.color = new Color(0, 1, 0, 1);
        currentHealth -= 1;
        yield return new WaitForSeconds(.25f);
        spriteRend.color = currColor;
        
        if (isBoss)
        {
            bossHealthChange?.Invoke((float)currentHealth / (float)maxHealth);
        }
    }

    public IEnumerator StopPoison()
    {
        yield return new WaitForSeconds(2.5f);
        CancelInvoke();
    }

    public IEnumerator Die()
    {
        if (dead) yield break;
        Debug.Log("I'm dead");
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
        if (!isFrozen) spriteRend.color = new Color(1, 1, 1, 1);
    }

    void resetEnemyHealth()
    {
        currentHealth = maxHealth;
    }
}
