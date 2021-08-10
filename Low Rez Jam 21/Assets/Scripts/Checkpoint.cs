using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator checkpointAnim;
    public bool hasTriggered = false;
    
    void Start()
    {
        Spawn.updateCheckpoint += resetCheckpointAnimation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Trigger animation");
            checkpointAnim.SetTrigger("checkpoint_reached");
            hasTriggered = true;
        }
    }

    public void resetCheckpointAnimation()
    {
        hasTriggered = false;
        checkpointAnim.SetTrigger("checkpoint_reset");
    }
}
