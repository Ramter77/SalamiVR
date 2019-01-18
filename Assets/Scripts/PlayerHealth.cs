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
    private HealthIndicator healthIndicatorScript;

	[Header ("Sound")]
    [Tooltip ("Step sound cooldown")]
    public float coughCD;
    public AudioSource headSound;
    public AudioClip coughClip;
    private float coughTimer;

    private Coroutine h;

    void Start () {
		health = maxHealth;

		tunnellingScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TunnellingOpaque>();

        healthIndicatorScript = GetComponentInChildren<HealthIndicator>();

        h = StartCoroutine(Heal(1));    //heal every second
    }

	//-----------------------------------------ALWAYS------------------------------------------//
	
	void Update () {
        //Debug.Log("Player Health: " + health);

        //ALWAYS DO:
        //Heal();           
        Cough();
		DisplayHealth();
    }

    IEnumerator Heal(int repeat)
    {
        if (health < maxHealth)
        {
            health++;       //heal 1 health each <repeat:
            StopCoroutine(h);
        }
        yield return new WaitForSeconds(repeat);
        StartCoroutine(Heal(1));
    }

    /*
    public void Heal() {
		if (health < maxHealth) {
			health++;		//heal each frame
		}
	}
    */

	public void Cough() {
		//Cough timer depends on health

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
        //Debug.Log(healthPct);
        coughCD = (1 + healthPct * 600) + 60;
        Debug.Log(coughCD);

        healthIndicatorScript.HealthIndicatorUpdate(healthPct);
	}

	void AdjustTunneling() {
		//Change effect feather & strengths of tunnel
		tunnellingScript.effectFeather = 0.1f + (((float)health / (float)maxHealth) / 10);
        tunnellingScript.angularVelocityStrength = 2 - ((float)health / (float)maxHealth);
        tunnellingScript.velocityStrength = 2 - ((float)health / (float)maxHealth);
    }
}
