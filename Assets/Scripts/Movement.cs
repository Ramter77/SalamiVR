using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Movement : MonoBehaviour {
    //This script handles movement and footstep sounds

    public float moveSpeed = 1;

    private Hand leftHand;
    //private SteamVR_Camera headCamera;
    private Transform headCamera;


    [Header ("Audio")]
    [Tooltip ("Step sound cooldown")]
    public float stepCD;
    public AudioSource sound;
    public AudioClip stepsSound;
    private bool firstStep;
    private float stepTimer; 

	void Awake () {
        leftHand = GetComponent<Hand>();

        //headCamera = transform.parent.GetComponentInChildren<SteamVR_Camera>();

        headCamera = transform.parent.Find("VRCamera");

        //headCamera = transform.root.Find("Head");
        Debug.Log("Found camera: " + headCamera);
	}

    void Move() {
        Vector3 forwardM = new Vector3(headCamera.forward.x, 0f, headCamera.forward.z);
        transform.root.position += forwardM * moveSpeed * Time.deltaTime;
    }
	
	void Update () {
        //Debug.Log(SteamVR_Input._default.inActions.Teleport.GetState(leftHand.handType));

        bool move = SteamVR_Input._default.inActions.Teleport.GetState(leftHand.handType);
        if (move) {
            //MOVE
            Move();
            

            //First Step SOUND
            /*
            if (firstStep) {
                sound.clip = stepsSound;
                sound.PlayOneShot(sound.clip);
                firstStep = false;
            }
            */

            //Step SOUND
            if (stepTimer <= 0) {
                sound.clip = stepsSound;
                sound.loop = true;
                sound.PlayOneShot(sound.clip);
                stepTimer = stepCD;
            }
            else {
                stepTimer -= Time.deltaTime;
            }
        }
        else {
            sound.loop = false;
            if (sound.clip == stepsSound && sound.isPlaying)
            {
                sound.Stop();                
            }
        }
	}
}
