using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    public GameObject Main;
    public GameObject Credits;
    public GameObject Credits2;
    public GameObject Controls;
    
    void Start()
    {
        Main.SetActive(true);
        Credits.SetActive(false);
        Credits2.SetActive(false);
        Controls.SetActive(false);
    }

    // Start is called before the first frame update
    public void PressStartToPlay()
    {
        SceneManager.LoadScene("Forest");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
