using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = Vector3.zero;

    private float platformOffset = 0f;

    private MovementController Controller;

    
    public float transitionSpeedY = .4f;
    
    private Vector2 targetY;
    private Vector2 targetYThisUpdate;

    
    void Start()
    {
        Controller = player.GetComponent<MovementController>();
        offset.z = -8f;
    }
    
    void Update()
    {
        if (Controller.m_Grounded)
        {
            platformOffset = player.transform.position.y;
        }

        targetY = new Vector2(transform.position.x, platformOffset + offset.y);
        targetYThisUpdate = Vector2.MoveTowards(transform.position, targetY, (transitionSpeedY * Time.deltaTime));

        transform.position = new Vector3(player.transform.position.x + offset.x,targetYThisUpdate.y, offset.z);
    }
}
