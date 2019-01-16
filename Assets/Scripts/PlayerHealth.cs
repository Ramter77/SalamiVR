using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sigtrap.VrTunnellingPro;

public class PlayerHealth : MonoBehaviour {
	//This script handles the players health, displays it to the UI, adjusts the tunneling effect,
	//Heals, takes damage from smoke, coughs

	private TunnellingOpaque tunnellingScript;

	[Header ("Health")]
	public static float healthPct;
	public static float health;
	public float maxHealth = 1000;
    public Text text;

    void Start () {
		health = maxHealth;

		tunnellingScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TunnellingOpaque>();
	}
	
	void Update () {
		//Debug.Log("Player Health: " + health);

        //Heal();
		AdjustTunneling();
		DisplayHealth();
    }

	void AdjustTunneling() {
		//Change effect feather of tunnel
		tunnellingScript.effectFeather = 0.1f + (((float)health / (float)maxHealth) / 10);
        tunnellingScript.angularVelocityStrength = 2 - ((float)health / (float)maxHealth);
        tunnellingScript.velocityStrength = 2 - ((float)health / (float)maxHealth);

        //Debug.Log(tunnellingScript.effectFeather);
    }

	void DisplayHealth() {
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

            UpdateHealthBar();
        }		
	}

	public void UpdateHealthBar() {
		healthPct = (float)health / (float)maxHealth;
        HealthIndicator.HealthIndicatorUpdate();
	}

	public void Cough() {
		//Cough timer depends on health
	}
}
