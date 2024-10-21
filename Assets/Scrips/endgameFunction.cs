using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class endgameFunction : MonoBehaviour
{
    public Button playagain;
    public Button quitgame;
    public IngameFuntion IngameFuntion;
    private void Awake()
    {
        IngameFuntion = FindObjectOfType<IngameFuntion>();
    }
    private void Start()
    {
        playagain.onClick.AddListener(playagaingame);
        quitgame.onClick.AddListener(quitgamenow);
    }

    private void quitgamenow()
    {
        SceneManager.LoadScene(0);
    }

    private void playagaingame()
    {
        SceneManager.LoadScene(1);
    }
}
