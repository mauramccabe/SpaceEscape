using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    void OnTriggerEnter(Collider player)
    {

    	if(SceneManager.GetActiveScene().buildIndex != 2)
    	{

    	
        	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
        	SceneManager.LoadScene(5);
        }
    }
}
