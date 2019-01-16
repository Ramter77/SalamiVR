using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Dialog : MonoBehaviour {
	public InteractSmoker _interactScript;
	public Hand hand;
	
	private void OnTriggerEnter(Collider other) {
        //if colliding with Smoker tagged triggered collider set interacting bool
        //if (other.tag == "Smoker") {
            //interacting = true;
        //}
        //else {
            //interacting = false;
        //}

		//if (other.tag == "Head") {
		//	_interactScript.interacting = true;
		//}












		/*
		//if player collides with triggered smoker collider



		
			//if pressing the button
			if (SteamVR_Input._default.inActions.Teleport.GetState(hand.handType)) {
                Debug.Log("Interact!!");

                disable collider so you can only do it once

				play sound file and stop
            }
		 */
    }

	private void OnTriggerExit(Collider other) {
		if (other.tag == "Head") {
			_interactScript.interacting = false;

			//executeDialog(name of smoker gameObject);
		}
    }
}
