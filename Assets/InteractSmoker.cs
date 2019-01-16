using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class InteractSmoker : MonoBehaviour {
	//public SteamVR_Action_Boolean action;


    

    public bool interacting = false;

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


    //make a function here that plays a certain sound depending on the given name of the confronted smoker
    //void executeDialog(name of smoker) {
        //if name == jan
        //  play jan dialog
    //}

    //OR
    //just make a prefab for each guy and then just play his dialog
    
}
