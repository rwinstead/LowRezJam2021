using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    public float invincibleTime = 5f;
    public float lastTimeDamaged = -50f;



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void takeDamage(int amt = 1)
    {
        
        if(Time.time - lastTimeDamaged > invincibleTime)
        {
            currentHealth = (currentHealth - amt);
            Debug.Log("Ouch. Took " + amt + " Damage. Current Health: " + currentHealth);
            lastTimeDamaged = Time.time;
        }
        else
        {
            Debug.Log("Invincible did not apply damage");
        }

        
        
        if (currentHealth <= 0)
        {
            // die
     
        }
    }
    
    public void healDamage(int amt = 1)
    {
        if(currentHealth < maxHealth)
        {
            currentHealth = (currentHealth + amt);
        }
        
        
    }
}
