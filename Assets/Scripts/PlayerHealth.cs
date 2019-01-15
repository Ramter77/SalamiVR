using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {


	public interaction interactScript;
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
			text.text = "Health: \n" + health.ToString();
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
		}		
	}


	private void OnTriggerEnter(Collider other) {
        //if colliding with Smoker tagged triggered collider set interacting bool
        //if (other.tag == "Smoker") {
            //interacting = true;
        //}
        //else {
            //interacting = false;
        //}

		if (other.tag == "Smoker") {
			interactScript.interacting = true;
		}
    }

	/// <summary>
    /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    private void OnTriggerExit(Collider other)
    {
        //interacting = false;
		//interactScript.interacting = false;

    }



	//Health display value
	//healthbarValue = RoundToInt(health / maxHealth);
}
