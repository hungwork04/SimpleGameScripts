using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuFunction : MonoBehaviour
{
    public Button playbtn;
    public Button Quitbtn;
    public Button fullscreen;
    private void Start()
    {
        playbtn.onClick.AddListener(playgame);
        Quitbtn.onClick.AddListener(quitgame);
        fullscreen.onClick.AddListener(fullscreengame);
    }
    public void playgame()
    {
        SceneManager.LoadScene(1);
    }
    public void fullscreengame() 
    {
        Screen.fullScreen = true;
    }
    public void quitgame()
    {
        Screen.fullScreen = false;
    }
}
