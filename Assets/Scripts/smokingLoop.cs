using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smokingLoop : MonoBehaviour {
    //This script only emits smoke in a loop and plays the in/exhale sounds

    private ParticleSystem pS;

	[Header ("Cooldown")]
	public int startCD = 1;
	public int minCD = 10;
	public int maxCD = 15;

	void Start () {
		pS = GetComponentInChildren<ParticleSystem>();

		float rnd = Random.Range(minCD, maxCD);

		InvokeRepeating("Smoke", startCD, rnd);		//call Smoke() after <startCD> seconds every <minCD-maxCD> seconds
	}

	void Smoke() {
		pS.Play();
        //Play exhale sound

        //wait some seconds and then play inhale sound
	}








/*
    private void OnTriggerEnter(Collider other)
    {
        //If player enters collider interact
        if (other.tag == "Head")
        {
            _interactScript.interacting = true;
        }
    }

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
