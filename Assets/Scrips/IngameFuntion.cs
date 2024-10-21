using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IngameFuntion : MonoBehaviour
{
    public Button homebtn;
    public Button howtoplay;
    public GameObject howtoplayscene;
    public Button playagainbtn;
    public GameObject playOne;
    public GameObject playTwo;
    public GameObject endgamescreen;
    private void Awake()
    {
        playOne = FindObjectOfType<body_p1>().gameObject;
        playTwo = FindObjectOfType<body_p3>().gameObject;
    }
    private void Start()
    {
        homebtn.onClick.AddListener(homegame);
        howtoplay.onClick.AddListener(howtoplayon);
        playagainbtn.onClick.AddListener(playagaingame);
        howtoplayon();
    }
    private void Update()
    {
        if (playOne==null || playTwo==null)
        {
            Invoke("endgameOn", 0.5f);
        }
    }
    public void endgameOn()
    {
        endgamescreen.SetActive(true);
        Time.timeScale = 0;
    }
    private void playagaingame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void homegame()
    {
        SceneManager.LoadScene(0);
    }
    public void howtoplayon()
    {
        if (howtoplayscene != null)
        {
            howtoplayscene.SetActive(true) ;
            Time.timeScale = 0f;
        }
    }
    public void xbutton()
    {
        if (howtoplayscene != null)
        {
            howtoplayscene.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
