using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {


	public interaction interactScript;
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






	//Health display value
	//healthbarValue = RoundToInt(health / maxHealth);
}
