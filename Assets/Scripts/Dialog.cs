using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Dialog : MonoBehaviour {
    //This script handles the dialog interaction (the initial sound that plays when the player collides with the
    //triggered collider and then presses the corresponding button)

    private bool button;
    private Hand rightHand;

    public float smokingDelay;	

	[Header ("Sound")]
	//public AudioClip dialogClip;
	public AudioClip[] dialogClip;
    private AudioSource sound;

	private void Start() {
        if (GameManager.Oculus)
        {
            button = SteamVR_Input._default.inActions.GrabPinch.GetState(rightHand.handType);
        }
        else
        {
            button = SteamVR_Input._default.inActions.Teleport.GetState(rightHand.handType);
        }

        if (rightHand == null) {
			//GameObject player = GameObject.FindGameObjectWithTag("Player");
			rightHand = GameObject.FindGameObjectWithTag("RightHand").GetComponent<Hand>();	//get right hand			
		}
		sound = GetComponent<AudioSource>();
	}

	public void playDialog(int number) {
		if (!sound.isPlaying) {
			sound.clip = dialogClip[number];
			sound.PlayOneShot(sound.clip);	//play dialog file
		}
	}
	
	//If player enters collider interact
	private void OnTriggerStay(Collider other) {
        //if colliding with Player collider		
        if (other.tag == "Head")
        {
			Debug.Log("-------// Colliding with player //-------------");
			//if player presses the interaction button
			if (button) {
				Debug.Log("----------------------------Interact-------------------------");

				if (!sound.isPlaying) {
					sound.clip = dialogClip[0];
					sound.PlayOneShot(sound.clip);	//play dialog file
				}

				gameObject.GetComponent<BoxCollider>().enabled = false;	//disable collider so you can only do it once
				gameObject.GetComponent<smokingLoop>().restartSmoking(smokingDelay);	//restart smoking after delay



				//Activate objective on UI
				if (transform.parent.name == "Mother") {
					//execute public function on UI which makes the objective text appear
					Debug.Log("Pass the cigarettes objective activated");
				}
			}
        }
    }
}
