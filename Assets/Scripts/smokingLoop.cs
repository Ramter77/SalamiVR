using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smokingLoop : MonoBehaviour {

	private ParticleSystem pS;

	[Header ("Cooldown")]
	public int startCD = 1;
	public int minCD = 10;
	public int maxCD = 15;

	void Start () {
		pS = GetComponentInChildren<ParticleSystem>();

		float rnd = Random.Range(minCD, maxCD);

		InvokeRepeating("Smoke", startCD, rnd);		//called after 5 seconds every 10-15 seconds
	}

	void Smoke() {
		pS.Play();
	}
}
