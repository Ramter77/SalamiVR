using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Dialog : MonoBehaviour {
	//This script handles the dialog interaction

	public Hand rightHand;

	private void Start() {
		if (rightHand == null) {
			
			//GameObject player = GameObject.FindGameObjectWithTag("Player");
			rightHand = GameObject.FindGameObjectWithTag("RightHand").GetComponent<Hand>();	//get right hand
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

				//disable collider so you can only do it once

				//play sound file and stop
			}
        }
    }

	/*
    private void OnTriggerExit(Collider other)
    {
        //If player exits collider stop interacting
        if (other.tag == "Head")
        {
            _interactScript.interacting = false;
        }
    }
	*/
}
