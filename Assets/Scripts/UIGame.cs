﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGame : MonoBehaviour
{

    public static UIGame instance;
    Match3 game;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        game = GameObject.FindObjectOfType<Match3>();

    }
    public void RePlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoHome()
    {
        SceneManager.LoadScene(0);

    }

    public void NextLevel()
    {

        LoadLevel.chooseLevel++;

        


        RePlay();
    }
}