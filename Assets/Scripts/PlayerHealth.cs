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

	[Header ("Sound")]
    [Tooltip ("Step sound cooldown")]
    public float coughCD;
    public AudioSource headSound;
    public AudioClip coughClip;
    private bool firstCough;
    private float coughTimer; 

    void Start () {
		health = maxHealth;

		tunnellingScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TunnellingOpaque>();
	}

	//-----------------------------------------ALWAYS------------------------------------------//
	
	void Update () {
		//Debug.Log("Player Health: " + health);

		//ALWAYS DO:
        //Heal();
		Cough();
		DisplayHealth();
    }

	public void Heal() {
		if (health < maxHealth) {
			health++;		//heal each frame
		}
	}

	public void Cough() {
		//Cough timer depends on health

		//First Cough SOUND
        /*
        if (firstCough) {
            headSound.clip = coughClip;
            headSound.PlayOneShot(headSound.clip);
            firstCough = false;
        }
        */

        //Cough SOUND
        if (coughTimer <= 0) {
            headSound.clip = coughClip;
            headSound.loop = true;
            headSound.PlayOneShot(headSound.clip);
            coughTimer = coughCD;
        }
        else {
            coughTimer -= Time.deltaTime;
        }

		//Debug.Log("Cough Cooldown: " + coughCD);
	}

	void DisplayHealth() {
		if (health > 0 && health <= maxHealth) {
			text.text = "" + health.ToString();
		}
	}

	//----------------------------------ONLY DO WHEN DAMAGED------------------------------------------//

	public void Damage() {
		if (health > 0) {
			health--;

			//ONLY DO WHEN DAMAGED:
            UpdateHealth();
			AdjustTunneling();
        }		
	}

	public void UpdateHealth() {
		healthPct = (float)health / (float)maxHealth;  

		//Adjust cough CD
		coughCD -= healthPct;

		HealthIndicator.HealthIndicatorUpdate();
	}

	void AdjustTunneling() {
		//Change effect feather & strengths of tunnel
		tunnellingScript.effectFeather = 0.1f + (((float)health / (float)maxHealth) / 10);
        tunnellingScript.angularVelocityStrength = 2 - ((float)health / (float)maxHealth);
        tunnellingScript.velocityStrength = 2 - ((float)health / (float)maxHealth);
    }
}
