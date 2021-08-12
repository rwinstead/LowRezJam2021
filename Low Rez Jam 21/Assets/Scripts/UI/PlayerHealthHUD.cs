using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthHUD : MonoBehaviour
{
    public GameObject Player;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;

    private int lastHealth = -1;
    private int currentHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        Health.updatePlayerHealth += updatePlayerHealthHUD;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void updatePlayerHealthHUD(int health)
    {
        currentHealth = health;
        if (currentHealth != lastHealth)
        {
            heart1.GetComponent<Image>().sprite = emptyHeart;
            heart2.GetComponent<Image>().sprite = emptyHeart;
            heart3.GetComponent<Image>().sprite = emptyHeart;

            //6 Health UI
            if (currentHealth >= 1) { heart1.GetComponent<Image>().sprite = halfHeart; }
            if (currentHealth >= 2) { heart1.GetComponent<Image>().sprite = fullHeart; }
            if (currentHealth >= 3) { heart2.GetComponent<Image>().sprite = halfHeart; }
            if (currentHealth >= 4) { heart2.GetComponent<Image>().sprite = fullHeart; }
            if (currentHealth >= 5) { heart3.GetComponent<Image>().sprite = halfHeart; }
            if (currentHealth >= 6) { heart3.GetComponent<Image>().sprite = fullHeart; }

            /*
            //3 Health UI
            if (currentHealth >= 2) { heart1.GetComponent<Image>().sprite = fullHeart; }
            if (currentHealth >= 4) { heart2.GetComponent<Image>().sprite = fullHeart; }
            if (currentHealth >= 6) { heart3.GetComponent<Image>().sprite = fullHeart; }
            */


        }
    }
}
