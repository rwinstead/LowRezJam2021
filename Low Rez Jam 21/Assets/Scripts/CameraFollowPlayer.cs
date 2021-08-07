using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = Vector3.zero;
    private float cameraOffsetY = 2.25f;
    
    private float cameraTargetY;
    
    public float transitionSpeedY = .4f;
    
    private Vector2 targetY;
    private Vector2 targetYThisUpdate;

    
    void Start()
    {
        offset.z = -8f;
        cameraTargetY = player.transform.position.y + cameraOffsetY;
    }
    
    void Update()
    {

        //If player has reached top allowable space adjust camera Y position
        if((transform.position.y - player.transform.position.y) > cameraOffsetY){
            cameraTargetY = player.transform.position.y + cameraOffsetY;
        }
        //If player has reached bottom allowable space adjust camera Y position
        else if ((player.transform.position.y - transform.position.y) > cameraOffsetY){
            cameraTargetY = player.transform.position.y - cameraOffsetY;
        }


        transform.position = new Vector3(player.transform.position.x + offset.x, cameraTargetY, offset.z);

    }
}
