using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Text objectiveText;
    public GameManager GameManager;
    
    

	void Start () {
        GameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        RemoveObjective();
    }
	
    public void AddObjective(string name) {


        if (name == "Mother") {
            objectiveText.text = ("Distribute cigarettes \n around. \n Cigarettes left: " + (GameManager.leftCigarettes + 1).ToString());
            
        }

        if (name == "Hubrecht Breukers")
        {
            objectiveText.text = ("Get your uncle \n some whiskey");

        }
    }

    public void RemoveObjective() {

        if (GameManager.CurrentObjective == 0)
        {
            objectiveText.text = ("Go talk to \n your mother");
            //highlight material/object
            //sound for when theres a new objective

        }

        else if (GameManager.CurrentObjective == 1)
        {
            objectiveText.text = ("Go talk to \n your uncle");
            //highlight material/object
            //sound for when theres a new objective
        }

        else if (GameManager.CurrentObjective == 2)
        {
            objectiveText.text = ("Next Objective");
            //highlight material/object
            //sound for when theres a new objective
        }
        else {
            Debug.Log("Objective Error: its a feature");
        }

    }
}
