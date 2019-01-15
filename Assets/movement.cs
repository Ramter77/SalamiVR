using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class movement : MonoBehaviour {


    public float moveSpeed = 1;

    private Hand hand;
    //private SteamVR_Camera headCamera;
    private Transform headCamera;

	// Use this for initialization
	void Awake () {
        hand = GetComponent<Hand>();

        //headCamera = transform.parent.GetComponentInChildren<SteamVR_Camera>();

        headCamera = transform.parent.Find("VRCamera");

        //headCamera = transform.root.Find("Head");
        Debug.Log("Found camera: " + headCamera);
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(SteamVR_Input._default.inActions.Teleport.GetState(hand.handType));

        bool move = SteamVR_Input._default.inActions.Teleport.GetState(hand.handType);
        if (move)
        {


            Vector3 forwardM = new Vector3(headCamera.forward.x, 0f, headCamera.forward.z);
            transform.root.position += forwardM * moveSpeed * Time.deltaTime;
        }
	}
}
