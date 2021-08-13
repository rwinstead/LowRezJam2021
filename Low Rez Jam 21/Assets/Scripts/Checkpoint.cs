using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator checkpointAnim;
    public bool hasTriggered = false;
    public int CheckpointID = 0;

    public static Action playCheckpointSFX;
    
    void Start()
    {
        Spawn.updateCheckpoint += updateCheckpointHandler;
    }

    private void OnDestroy()
    {
        Spawn.updateCheckpoint -= updateCheckpointHandler;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            checkpointAnim.SetTrigger("checkpoint_reached");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            checkpointAnim.ResetTrigger("checkpoint_reached");
        }
    }

    public void updateCheckpointHandler(int triggeredID)
    {
        if(triggeredID != CheckpointID)
        {
            if (hasTriggered)
            {
                checkpointAnim.SetTrigger("checkpoint_reset");
            }
            hasTriggered = false;
            
        }
        if (triggeredID == CheckpointID && hasTriggered == false)
        {
            
            playCheckpointSFX?.Invoke();
            hasTriggered = true;
        }

    }
}
