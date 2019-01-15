using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public static float health;
	public float maxHealth = 1000;
    public Text text;

    // Use this for initialization
    void Start () {
		health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log("Player Health: " + health);

        //Heal();

        text.text = "Health: \n" + health.ToString();


    }

	public void Heal() {
		if (health < maxHealth) {
			health++;		//heal each frame
		}
	}

	public void Damage() {
		if (health > 0) {
			health--;
		}		
	}
}
