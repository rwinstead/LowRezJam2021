using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource backgroundTrack;
    public AudioSource SFXTrack;

    public AudioClip mainBGLoop;
    public AudioClip bossBGLoop;
    public AudioClip creditsLoop;

    public AudioClip checkpointSFX;
    public AudioClip unlockRuneSFX;

    public AudioClip playerDeathSFX;
    public AudioClip meleeSFX;
    public AudioClip takeDamageSFX;
    public AudioClip blueSpellSFX;
    public AudioClip greenSpellSFX;
    public AudioClip yellowSpellSFX;


    // Start is called before the first frame update
    void Start()
    {
        backgroundTrack.clip = mainBGLoop;
        backgroundTrack.Play();

        Checkpoint.playCheckpointSFX += playCheckpointSFXHandler;
        ChestOpenTrigger.unlockRune += playUnlockRuneSFXHandler;

        Health.playTakeDamageSFX += playTakeDamageSFXHandler;
        Health.playerRespawn += playDeathSFXHandler;

        Spellcasting.playMeleeSFX += playMeleeSFXHandler;
        Spellcasting.playSpellSFX += playSpellSFXHandler;

        CathedralExterior.bossArenaTeleport += playBossMusicHandler;

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
        SFXTrack.PlayOneShot(takeDamageSFX, 1f);
    }

    void playDeathSFXHandler()
    {
        SFXTrack.PlayOneShot(playerDeathSFX, 0.6f);
    }

    void playMeleeSFXHandler()
    {
        SFXTrack.PlayOneShot(meleeSFX, 0.3f);
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

    void playUnlockRuneSFXHandler(int runeID)
    {
        SFXTrack.PlayOneShot(unlockRuneSFX, 0.5f);
    }

    void playBossMusicHandler()
    {
        backgroundTrack.clip = bossBGLoop;
        backgroundTrack.Play();
    }

}
