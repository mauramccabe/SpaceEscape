using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioClip jumpSound1, jumpSound2, jumpSound3, PressurePlate, door, dash, respawn;
    static AudioSource audioSrc;
    static int randomPick;
    void Start()
    {
    	jumpSound1 = Resources.Load<AudioClip>("Synth Whoosh 3_3");
    	jumpSound2 = Resources.Load<AudioClip>("Synth Whoosh 3_1");
    	jumpSound3 = Resources.Load<AudioClip>("Synth Whoosh 3_2");
    	PressurePlate = Resources.Load<AudioClip>("Teleport 8_1");
    	door = Resources.Load<AudioClip>("Door 4 Open");
        dash = Resources.Load<AudioClip>("Shield Device 3 Stop");
        respawn = Resources.Load<AudioClip>("Device 4 Stop");

        audioSrc = GetComponent<AudioSource> ();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound (string clip)
    {
    	switch(clip)
    	{
    		case "jump":

                randomPick = Random.Range(0, 3);
                if(randomPick == 0) {
                    audioSrc.PlayOneShot(jumpSound1);
                    break;
                }else if(randomPick == 1) {
                    audioSrc.PlayOneShot(jumpSound2);
                    break;
                } else {
                    audioSrc.PlayOneShot(jumpSound3);
                    break;
                }


    		case "plate":
    		audioSrc.PlayOneShot (PressurePlate);
    		break;

    		case "door":
    		audioSrc.PlayOneShot (door);
    		break;

            case "dash":
            audioSrc.PlayOneShot(dash);
            break;

            case "respawn":
            audioSrc.PlayOneShot(respawn);
            break;
        }
    }

}
