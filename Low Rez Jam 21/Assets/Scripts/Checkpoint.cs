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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            checkpointAnim.SetTrigger("checkpoint_reached");
        }
    }

    public void updateCheckpointHandler(int triggeredID)
    {
        if(triggeredID != CheckpointID)
        {
            hasTriggered = false;
            checkpointAnim.SetTrigger("checkpoint_reset");
        }
        if (triggeredID == CheckpointID && hasTriggered == false)
        {
            
            playCheckpointSFX?.Invoke();
            hasTriggered = true;
        }

    }
}
