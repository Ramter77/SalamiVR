﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smokingLoop : MonoBehaviour {

    [Tooltip ("Reference to the interaction script")]
    public interaction _interactScript;

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
	}

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
}
