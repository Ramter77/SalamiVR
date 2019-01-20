using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateChatButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void deactivateChatButton() {

        gameObject.SetActive(false);

    }
}
