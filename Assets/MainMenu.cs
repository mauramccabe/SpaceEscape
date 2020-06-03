using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
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
}
