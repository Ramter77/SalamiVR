using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class interaction : MonoBehaviour {
	//public SteamVR_Action_Boolean action;


    public bool interacting;

    private Hand hand;

	void Awake () {
        hand = GetComponent<Hand>();
	}
	
	void Update () {
        //if in triggered collider


        if (interacting)
        {
            Debug.Log("Doneffffffffffffffffffffffffffffffff");
            //if pressing the button
            if (SteamVR_Input._default.inActions.Teleport.GetState(hand.handType)) {
                Debug.Log("Interact!!");

                interacting = false;
            }
        }



        //DEBUG
        //Debug.Log(SteamVR_Input._default.inActions.GrabGrip.GetState(hand.handType));
	}

    
}
