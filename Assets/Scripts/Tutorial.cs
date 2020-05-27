using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject txt;
    public int timer;

    // Start is called before the first frame update
    void Start()
    {
        txt.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            txt.SetActive(true);
            StartCoroutine("WaitFor");
        }

    }
    IEnumerator WaitFor()
    {
        yield return new WaitForSeconds(timer);
        Destroy(txt);
        Destroy(gameObject);
    }
}
