using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using UnityEngine.UI;

public class Dialog : MonoBehaviour {
    //This script handles the dialog interaction (the initial sound that plays when the player collides with the
    //triggered collider and then presses the corresponding button)

    private Hand rightHand;

    public float smokingDelay;	

	[Header ("Sound")]
	//public AudioClip dialogClip;
	public AudioClip[] dialogClip;
    private AudioSource sound;
    private UIController UIController;

	private void Start() {
        if (rightHand == null) {
			//GameObject player = GameObject.FindGameObjectWithTag("Player");
			rightHand = GameObject.FindGameObjectWithTag("RightHand").GetComponent<Hand>();	//get right hand	
            UIController = GameObject.FindGameObjectWithTag("UI").GetComponent<UIController>();
        }
		sound = GetComponent<AudioSource>();
	}

    //TEST SOUND WITH "F" KEY
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (transform.parent.name == "Hubrecht Breukers")
            {
                sound.clip = dialogClip[0];
                sound.PlayOneShot(sound.clip);  //play dialog file
            }
        }
    }

    //PLAY CORRESPONDING DIALOG on clicking the seperate UI options
	public void playDialog(int number) {
        //if (sound.isPlaying) {

        /*
        //Debug.Log(sound.clip != dialogClip[0]);
        if (sound.clip != dialogClip[number]) {
            if (!sound.isPlaying)
            {


                sound.clip = dialogClip[number];
                sound.PlayOneShot(sound.clip);  //play dialog file
            }
        }
        */

        if (sound.clip != dialogClip[0])
        {
            sound.clip = dialogClip[0];
            sound.PlayOneShot(sound.clip);  //play dialog file
        }
        else
        {
            if (!sound.isPlaying)
            {
                sound.clip = dialogClip[0];
                sound.PlayOneShot(sound.clip);  //play dialog file
            }
        }
        //}
    }
	
	//If player enters collider interact
	private void OnTriggerStay(Collider other) {
        //if colliding with Player collider		
        if (other.tag == "Head")
        {
			//Debug.Log("-------// Colliding with player //-------------");
            //if player presses the interaction button

            //OCULUS//
            //if (SteamVR_Input._default.inActions.GrabPinch.GetState(rightHand.handType)) { 

            //VIVE//
            if (SteamVR_Input._default.inActions.Teleport.GetState(rightHand.handType)) {
				Debug.Log("----------------------------Interact-------------------------");

                /*
				if (!sound.isPlaying) {
					sound.clip = dialogClip[0];
					sound.PlayOneShot(sound.clip);	//play dialog file
				}
                */

                //if in/exhaling
                if (sound.clip != dialogClip[0])
                {
                    sound.clip = dialogClip[0];
                    sound.PlayOneShot(sound.clip);  //play dialog file
                }
                else
                {
                    if (!sound.isPlaying)
                    {
                        sound.clip = dialogClip[0];
                        sound.PlayOneShot(sound.clip);  //play dialog file
                    }
                }
                

                gameObject.GetComponent<BoxCollider>().enabled = false;	//disable collider so you can only do it once
                //gameObject.GetComponent<smokingLoop>().restartSmoking(smokingDelay);	//restart smoking after delay



                //Activate objective on UI
                if (transform.parent.name == "Mother") {
                    //execute public function on UI which makes the objective text appear
                    UIController.AddObjective("Mother");
					Debug.Log("Pass the cigarettes objective activated");
				}
                else if (transform.parent.name == "Hubrecht Breukers")
                {
                    //execute public function on UI which makes the objective text appear
                    UIController.AddObjective("Hubrecht Breukers");
                    Debug.Log("Bring Whiskey");
                }
            }
        }
    }
}
