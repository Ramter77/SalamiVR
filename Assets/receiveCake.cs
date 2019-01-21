using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class receiveCake : MonoBehaviour {

    public GameManager gm;

    void Start () {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        }
    }
	
	// Update is called once per frame
	void Update () {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (tag == "fakeCake")
        {
            Debug.Log("Received fakeCake");

            if (GameManager.activateCake)
            {
                gm.incrementCake();

                gameObject.SetActive(false);                
            }
        }
    }
}
