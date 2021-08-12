using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource backgroundTrack;
    public AudioSource SFXTrack;

    public AudioClip menuLoop;
    public AudioClip mainBGLoop;
    public AudioClip bossBGLoop;
    public AudioClip creditsLoop;

    public AudioClip checkpointSFX;
    public AudioClip deathSFX;
    public AudioClip meleeSFX;
    public AudioClip takeDamageSFX;
    public AudioClip blueSpellSFX;
    public AudioClip greenSpellSFX;
    public AudioClip yellowSpellSFX;


    // Start is called before the first frame update
    void Start()
    {
        backgroundTrack.clip = mainBGLoop;
        //backgroundTrack.Play();

        Checkpoint.playCheckpointSFX += playCheckpointSFXHandler;
        Health.playTakeDamageSFX += playTakeDamageSFXHandler;
        Spellcasting.playMeleeSFX += playMeleeSFXHandler;
        Spellcasting.playSpellSFX += playSpellSFXHandler;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void playCheckpointSFXHandler()
    {
        SFXTrack.PlayOneShot(checkpointSFX, 0.5f);
    }

    void playTakeDamageSFXHandler()
    {
        SFXTrack.PlayOneShot(takeDamageSFX, 0.7f);
    }

    void playMeleeSFXHandler()
    {
        SFXTrack.PlayOneShot(meleeSFX, 0.5f);
    }

    void playSpellSFXHandler(int runeID)
    {
        if(runeID == 1)
        {
            SFXTrack.PlayOneShot(blueSpellSFX, 0.5f);
        }
        if (runeID == 2)
        {
            SFXTrack.PlayOneShot(yellowSpellSFX, 0.5f);
        }
        if (runeID == 3)
        {
            SFXTrack.PlayOneShot(greenSpellSFX, 0.5f);
        }
    }
}
