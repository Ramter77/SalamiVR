using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIndicator : MonoBehaviour {

    private static float healthPercentage;
    private static Material material;

	// Use this for initialization
	void Start () {

        healthPercentage = PlayerHealth.healthPct;
        material = GetComponent<Renderer>().material;

	}

    public static void HealthIndicatorUpdate() {
        healthPercentage = PlayerHealth.healthPct;
        material.SetFloat("_Cutoff", 1f - healthPercentage);
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
