using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider player)
    {
        int sc = SceneManager.GetActiveScene().buildIndex;
        if (sc == 2)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(sc + 1);
        }

    }
}