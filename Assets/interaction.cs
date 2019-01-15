using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class interaction : MonoBehaviour {
	public SteamVR_Action_Boolean grabPinch;


    
    public float moveSpeed = 1;

    public bool interacting;

    private Hand hand;

	void Awake () {
        hand = GetComponent<Hand>();
	}
	
	void Update () {
        //if in triggered collider
        if (interacting)
        {
            //if pressing the button
            if (SteamVR_Input._default.inActions.Teleport.GetState(hand.handType)) {
                Debug.Log("Interact!!");

                interacting = false;
            }
        }



        //DEBUG
        //Debug.Log(SteamVR_Input._default.inActions.GrabGrip.GetState(hand.handType));
	}

    private void OnTriggerStay(Collider other) {
        //if colliding with Smoker tagged triggered collider set interacting bool
        if (other.tag == "Smoker") {
            interacting = true;
        }
        else {
            interacting = false;
        }
    }
}
