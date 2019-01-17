using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Dialog : MonoBehaviour {
	//This script handles the dialog interaction (the initial sound that plays when the player collides with the
	//triggered collider and then presses the corresponding button)

	public float smokingDelay;
	private Hand rightHand;

	[Header ("Sound")]
	public AudioClip clip;
    private AudioSource sound;

	private void Start() {
		if (rightHand == null) {
			
			//GameObject player = GameObject.FindGameObjectWithTag("Player");
			rightHand = GameObject.FindGameObjectWithTag("RightHand").GetComponent<Hand>();	//get right hand

			sound = GetComponent<AudioSource>();
		}
	}
	
	//If player enters collider interact
	private void OnTriggerStay(Collider other) {
        //if colliding with Player collider		
        if (other.tag == "Head")
        {
			Debug.Log("-------// Colliding with player //-------------");
			//if player presses the interaction button
			if (SteamVR_Input._default.inActions.Teleport.GetState(rightHand.handType)) {
				Debug.Log("----------------------------Interact-------------------------");

				sound.clip = clip;
				sound.PlayOneShot(sound.clip);	//play sound file

				gameObject.GetComponent<BoxCollider>().enabled = false;	//disable collider so you can only do it once
				gameObject.GetComponent<smokingLoop>().restartSmoking(smokingDelay);	//restart smoking after delay
			}
        }
    }
}
