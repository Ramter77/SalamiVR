using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceivePickup : MonoBehaviour {
	//This script handles receiving pickups, playing a thanks sound and changes the UI accordingly

	public GameManager gm;

	[Header ("Sound")]
	public AudioClip[] thanksClip;
    private AudioSource sound;

	[Header ("Booleans")]
	private bool alreadyReceivedCigarette;
	private bool alreadyReceivedBottle;

	void Start () {
		if (gm == null) {
			gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
		}		
		sound = GetComponent<AudioSource>();
	}
	
	private void OnTriggerEnter(Collider other) {
		//if its a cigarette
		string tag = other.tag;
		if (tag == "Cigarette") {
			Debug.Log("Distributed: " + other.name);

			//if not already received, which changes to true on successful action
			if (!alreadyReceivedCigarette) {	
				alreadyReceivedCigarette = true;

				//increment amount of cigarettes distributed & check if objective completed
				gm.incrementCigarette();	//pass   gameObject.name   ?

				sound.clip = thanksClip[0];		//thanks 0
				sound.PlayOneShot(sound.clip);	//play thanks file
			}
		}

		else if (tag == "Bottle") {
			Debug.Log("Received Bottle");

			//check if recipient is allowed to get that item
			if (transform.parent.parent.name == "Hubrecht Breukers") {
				//gm.incrementBottle();

				sound.clip = thanksClip[0];		//thanks 0
				sound.PlayOneShot(sound.clip);	//play thanks file
			}
		}
	}
}
