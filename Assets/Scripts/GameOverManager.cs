﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickRetry()
    {
        //shooting 씬 로드
        SceneManager.LoadScene("SampleScene");
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}
