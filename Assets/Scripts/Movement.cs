using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Movement : MonoBehaviour {
    //This script handles movement and footstep sounds
    private bool button;
    private Hand leftHand;

    public float moveSpeed = 1;    
    private Transform headCamera;

    [Header ("Sound")]
    [Tooltip ("Step sound cooldown")]
    public float stepCD;
    public AudioSource playerSound;
    public AudioClip stepsSound;
    private bool firstStep;
    private float stepTimer;    

    void Awake () {
        if (GameManager.Oculus)
        {
            button = SteamVR_Input._default.inActions.GrabPinch.GetState(leftHand.handType);
        }
        else
        {
            button = SteamVR_Input._default.inActions.Teleport.GetState(leftHand.handType);
        }


        leftHand = GetComponent<Hand>();
        headCamera = transform.parent.Find("VRCamera");
        Debug.Log("Found camera: " + headCamera);
	}

    void Move() {
        Vector3 forwardM = new Vector3(headCamera.forward.x, 0f, headCamera.forward.z);
        transform.root.position += forwardM * moveSpeed * Time.deltaTime;
    }

    void MoveSound() {
        //First Step SOUND
        if (firstStep) {
            playerSound.clip = stepsSound;
            playerSound.PlayOneShot(playerSound.clip);
            firstStep = false;
        }

        //Step SOUND
        if (stepTimer <= 0) {
            playerSound.clip = stepsSound;
            playerSound.loop = true;
            playerSound.PlayOneShot(playerSound.clip);
            stepTimer = stepCD;
        }
        else {
            stepTimer -= Time.deltaTime;
        }
    }
	
	void Update () {
        //MOVE
        bool move = button;
        if (move) {            
            Move();
            MoveSound();            
        }
        else {  //stop sound
            playerSound.loop = false;
            if (playerSound.clip == stepsSound && playerSound.isPlaying)
            {
                playerSound.Stop();                
            }
        }
	}
}
