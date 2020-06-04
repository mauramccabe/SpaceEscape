using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    void Start() {
        Cursor.lockState = CursorLockMode.None;
    }

    public void PlayGame ()
    {
    	SceneManager.LoadScene(0);
    }
    public void theShip()
    {
    	SceneManager.LoadScene(0);
    }
    public void mars()
    {
    	SceneManager.LoadScene(1);
    }
    public void theCaves()
    {
    	SceneManager.LoadScene(2);
    }
    public void LevelSelect()
    {
    	SceneManager.LoadScene(4);
    }
    public void back()
    {
    	SceneManager.LoadScene(3);
    }
}
