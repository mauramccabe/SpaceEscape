﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        
     if(Input.GetKeyDown(KeyCode.M))
     {

        SceneManager.LoadScene(0);
     }

    }
}
