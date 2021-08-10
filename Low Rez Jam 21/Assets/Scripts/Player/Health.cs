using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    public float invincibleTime = 1f;
    public float lastTimeDamaged = -50f;

    SpriteRenderer spriteRend;
    bool blinkingWhite = false;

    public static Action<int> updatePlayerHealth;
    public static Action playerRespawn;



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void takeDamage(int amt = 1)
    {
        
        if(Time.time - lastTimeDamaged > invincibleTime)
        {
            StartCoroutine("FlashWhite");
            currentHealth = (currentHealth - amt);
            Debug.Log("Ouch. Took " + amt + " Damage. Current Health: " + currentHealth);
            lastTimeDamaged = Time.time;
            updatePlayerHealth?.Invoke(currentHealth);
        }
        else
        {
            Debug.Log("Invincible did not apply damage");
        }

        
        
        if (currentHealth <= 0)
        {
            // die
            playerRespawn?.Invoke();
            healDamage(99);
        }
    }

    public IEnumerator FlashWhite()
    {
        if (!blinkingWhite)
        {
            blinkingWhite = true;
            spriteRend.material.SetFloat("_FlashAmount", .75f);
            yield return new WaitForSeconds(.2f);
            spriteRend.material.SetFloat("_FlashAmount", 0);
            blinkingWhite = false;
        }
    }
    
    public void healDamage(int amt = 1)
    {
        if(currentHealth < maxHealth)
        {
            currentHealth = (currentHealth + amt);
            if (currentHealth > maxHealth) { currentHealth = maxHealth; }
            Debug.Log("Yay! Healed " + amt + " Damage. Current Health: " + currentHealth);
            updatePlayerHealth?.Invoke(currentHealth);
        }
        
        
    }
}
