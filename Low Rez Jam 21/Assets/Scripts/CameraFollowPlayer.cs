using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = Vector3.zero;

    void Update()
    {
        transform.position = new Vector3(player.position.x + offset.x, 0 + offset.y, offset.z); 
    }
}
