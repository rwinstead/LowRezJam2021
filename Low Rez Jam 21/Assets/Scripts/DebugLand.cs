using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLand : MonoBehaviour
{

    public bool unlockRunes = true;
    public bool isImmortal = true;
    public bool startInBossFight = false;

    public GameObject player;
    public Transform insideCathedral;

    // Start is called before the first frame update
    void Start()
    {
        if (unlockRunes)
        {
            Debug.Log("remote unlock");
            player.GetComponent<Spellcasting>().unlockRuneCasting(1);
            player.GetComponent<Spellcasting>().unlockRuneCasting(2);
            player.GetComponent<Spellcasting>().unlockRuneCasting(3);
        }
        if (isImmortal)
        {
            player.GetComponent<Health>().invincibleTime = 99999f;
        }
        if (startInBossFight)
        {
            Debug.Log("Starting in Boss arena");
            player.transform.position = insideCathedral.position;
        }

    }

    // Update is called once per frame
}
