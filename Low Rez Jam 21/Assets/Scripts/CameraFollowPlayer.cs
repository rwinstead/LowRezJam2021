using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = Vector3.zero;
    private float cameraOffsetY = 2.25f;
    

    private float platformOffset = 0f;


    private MovementController Controller;
    private float cameraTargetY;
    
    public float transitionSpeedY = .4f;
    
    private Vector2 targetY;
    private Vector2 targetYThisUpdate;

    
    void Start()
    {
        Controller = player.GetComponent<MovementController>();
        offset.z = -8f;
        cameraTargetY = player.transform.position.y + cameraOffsetY;
    }
    
    void Update()
    {

        if((transform.position.y - player.transform.position.y) > cameraOffsetY){
            cameraTargetY = player.transform.position.y + cameraOffsetY;
        }
        else if ((player.transform.position.y - transform.position.y) > cameraOffsetY){
            cameraTargetY = player.transform.position.y - cameraOffsetY;
        }


        transform.position = new Vector3(player.transform.position.x + offset.x, cameraTargetY, offset.z);

        /*
        if (Controller.m_Grounded)
        {
            platformOffset = player.transform.position.y;
        }

        targetY = new Vector2(transform.position.x, platformOffset + offset.y);
        targetYThisUpdate = Vector2.MoveTowards(transform.position, targetY, (transitionSpeedY * Time.deltaTime));

        transform.position = new Vector3(player.transform.position.x + offset.x,targetYThisUpdate.y, offset.z);

    */
    }
}
