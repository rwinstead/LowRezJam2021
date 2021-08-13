using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipHUD : MonoBehaviour
{

    public GameObject Tooltip;
    public GameObject player;
    
    private Text TooltipText;
    private Color baseColor;
    // Start is called before the first frame update
    void Start()
    {
        TooltipText = Tooltip.GetComponent<Text>();
        ChestOpenTrigger.chestPlayerTooltip += chestPlayerTooltipHUD;
        TooltipTrigger.TooltipTriggerAction += TooltipTriggerHUD;
        StartCoroutine(FadeTextToFullAlpha(2f, TooltipText, "WASD To Move\nSpace to Jump"));
        baseColor = TooltipText.color;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void chestPlayerTooltipHUD(int val)
    {
        if (val == 0)
        {
            StartCoroutine(FadeTextToZeroAlpha(1f, TooltipText));
        }
        if (val == 1)
        {
            StartCoroutine(FadeTextToFullAlpha(1f, TooltipText,"Press F to Open"));
        }
        if (val == 2)
        {
            StartCoroutine(FadeTextToFullAlpha(2f, TooltipText, "Press Q to Cast", 3f));
        }
        if (val == 3)
        {
            StartCoroutine(FadeTextToFullAlpha(2f, TooltipText, "Press Tab to Switch Runes", 3f));
        }
    }

     void TooltipTriggerHUD(int val)
    {
        Debug.Log(val);
        if (val == 0)
        {
            StartCoroutine(FadeTextToZeroAlpha(2f, TooltipText));
        }
        if (val == 2)
        {
            StartCoroutine(FadeTextToZeroAlpha(2f, TooltipText));
        }
        if (val == 4)
        {
            Spellcasting sc = player.GetComponent<Spellcasting>();
            if(sc.blueRuneUnlocked == false || sc.greenRuneUnlocked == false || sc.yellowRuneUnlocked == false)
            {
                StartCoroutine(FadeTextToFullAlpha(2f, TooltipText, "All 3 Runes Are Needed To Open"));
            }
        }
    }

    public IEnumerator FadeTextToFullAlpha(float t, Text i,string text ,float wait = 0)
    {
        //i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        yield return new WaitForSeconds(wait);
        i.text = text;
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
        yield return new WaitForSeconds(10);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }

    public IEnumerator FadeTextToZeroAlpha(float t, Text i, float wait = 0)
    {
        //i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        yield return new WaitForSeconds(wait);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
        i.text = "";
    }
}
