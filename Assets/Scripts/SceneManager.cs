using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://answers.unity.com/questions/1298691/best-way-to-reference-player-class-instance.html

public class SceneManager : MonoBehaviour {
    public GameObject player;
    public KillPlaneTrigger killPlane;
    public CharacterController controller;

    public static SceneManager Instance { get; private set; }
    void Awake() {

        if (Instance == null) { Instance = this; } else { Destroy(gameObject); }

        player = GameObject.FindGameObjectWithTag("Player");
        killPlane = GameObject.FindGameObjectWithTag("KillPlane").GetComponent<KillPlaneTrigger>();
        controller = player.GetComponent<CharacterController>();

    }

}
