using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class fadeOnCollision : MonoBehaviour {

	private SteamVR_Fade fadeScript;

	private void Start() {
		fadeScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SteamVR_Fade>();
	}

	private void OnTriggerStay(Collider other) {
		if (other.tag == "wall") {
			fadeScript.OnStartFade(Color.green, 1f, true);
		}
	}
}
