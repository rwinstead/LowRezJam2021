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

    private int lastHealth = 0;
    private int currentHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = Player.GetComponent<Health>().currentHealth;
        if (currentHealth != lastHealth)
        {
            heart1.GetComponent<Image>().sprite = emptyHeart;
            heart2.GetComponent<Image>().sprite = emptyHeart;
            heart3.GetComponent<Image>().sprite = emptyHeart;

            if (currentHealth >= 1) { heart1.GetComponent<Image>().sprite = fullHeart; }
            if (currentHealth >= 2) { heart2.GetComponent<Image>().sprite = fullHeart; }
            if (currentHealth >= 3) { heart3.GetComponent<Image>().sprite = fullHeart; }

        }
    }
}
