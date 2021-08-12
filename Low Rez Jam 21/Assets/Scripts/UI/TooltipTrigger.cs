using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    public int EnterTriggerID = -1;
    public int ExitTriggerID = -1;
    public float triggercooldownEnter = 0.5f;
    public float triggercooldownExit = 0.2f;
    private float lastTriggerTimeEnter = -99f;
    private float lastTriggerTimeExit = -99f;

    public static Action<int> TooltipTriggerAction;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if((Time.time - lastTriggerTimeEnter) > triggercooldownEnter)
            {
                TooltipTriggerAction?.Invoke(EnterTriggerID);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((Time.time - lastTriggerTimeExit) > triggercooldownExit)
        {
            TooltipTriggerAction?.Invoke(ExitTriggerID);
        }
    }
}
