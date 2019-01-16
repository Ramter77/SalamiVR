using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
	public InteractSmoker _interactScript;

	[Header ("Health")]
	public static float healthPct;
	public static float health;
	public float maxHealth = 1000;
    public Text text;

    void Start () {
		health = maxHealth;
	}
	
	void Update () {
		//Debug.Log("Player Health: " + health);

        //Heal();


		if (health > 0 && health <= maxHealth) {
			text.text = "" + health.ToString();
		}
    }

	public void Heal() {
		if (health < maxHealth) {
			health++;		//heal each frame
		}
	}

	public void Damage() {
		if (health > 0) {
			health--;
            healthPct = (float)health / (float)maxHealth;
            HealthIndicator.HealthIndicatorUpdate();

        }		
	}

	public void Cough() {
		//Cough timer depends on health
	}

	//public void IncreaseTunnel()		decrease FOV with Vignette
}
