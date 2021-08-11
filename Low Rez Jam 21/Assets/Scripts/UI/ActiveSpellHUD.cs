using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveSpellHUD : MonoBehaviour
{

    public GameObject spellSlot1;
    public GameObject spellSlot2;
    public GameObject spellSlot3;

    public Sprite blueActive;
    public Sprite blueInactive;
    public Sprite greenActive;
    public Sprite greenInactive;
    public Sprite yellowActive;
    public Sprite yellowInactive;
    public Sprite lockedSpell;

    public GameObject player;

    private bool spellSlot1Unlocked = false;
    private bool spellSlot2Unlocked = false;
    private bool spellSlot3Unlocked = false;

    // Start is called before the first frame update
    void Start()
    {
        spellSlot1.GetComponent<Image>().sprite = lockedSpell;
        spellSlot2.GetComponent<Image>().sprite = lockedSpell;
        spellSlot3.GetComponent<Image>().sprite = lockedSpell;

        ChestOpenTrigger.unlockRune += unlockRuneHUD;
        Spellcasting.activateRune += activateRuneHUD;

    }

    // Update is called once per frame
    void Update()
    {
        //
    }

    void unlockRuneHUD(int RuneID)
    {
        if (RuneID == 1)
        {
            spellSlot1Unlocked = true;
            spellSlot1.GetComponent<Image>().sprite = blueInactive;
        }
        if (RuneID == 2)
        {
            spellSlot2Unlocked = true;
            spellSlot2.GetComponent<Image>().sprite = yellowInactive;
        }
        if (RuneID == 3)
        {
            spellSlot3Unlocked = true;
            spellSlot3.GetComponent<Image>().sprite = greenInactive;
        }
    }

    void activateRuneHUD(int RuneID)
    {
        
        spellSlot1.GetComponent<Image>().sprite = lockedSpell;
        spellSlot2.GetComponent<Image>().sprite = lockedSpell;
        spellSlot3.GetComponent<Image>().sprite = lockedSpell;

        if (spellSlot1Unlocked) { spellSlot1.GetComponent<Image>().sprite = blueInactive; }
        if (spellSlot2Unlocked) { spellSlot2.GetComponent<Image>().sprite = yellowInactive; }
        if (spellSlot3Unlocked) { spellSlot3.GetComponent<Image>().sprite = greenInactive; }

        if (RuneID == 1)
        {
            spellSlot1.GetComponent<Image>().sprite = blueActive;
        }
        if (RuneID == 2)
        {
            spellSlot2.GetComponent<Image>().sprite = yellowActive;
        }
        if (RuneID == 3)
        {
            spellSlot3.GetComponent<Image>().sprite = greenActive;
        }
    }
}
