﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioClip jumpSound, PressurePlate, door;
    static AudioSource audioSrc;

    void Start()
    {
    	jumpSound = Resources.Load<AudioClip>("Synth Whoosh 3_3");
    	PressurePlate = Resources.Load<AudioClip>("Teleport 8_1");
    	door = Resources.Load<AudioClip>("Door 4 Open");

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
    	
    		audioSrc.PlayOneShot (jumpSound);
    		break;
    		
    		case "plate":
    		audioSrc.PlayOneShot (PressurePlate);
    		break;

    		case "door":
    		audioSrc.PlayOneShot (door);
    		break;
    	}
    }

}