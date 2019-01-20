using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Text objectiveText;
    public GameManager GameManager;


    public activateBubble HubrechtBubble;
    public activateBubble RadioBubble;


    void Start () {
        GameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        RemoveObjective();
    }

    public void updateLeftCigarettes ()
    {
        objectiveText.text = ("Distribute cigarettes \n around. \n Cigarettes left: " + (GameManager.leftCigarettes).ToString());
    }
	
    public void AddObjective(string name) {


        if (name == "Mother") {
            GameManager.cigaretteDistributionEnabled = true;
            objectiveText.text = ("Distribute cigarettes \n around. \n Cigarettes left: " + (GameManager.leftCigarettes).ToString());
        }

        else if (name == "Hubrecht Breukers")
        {
            Debug.Log("Bring Whiskey objective activated");

            GameManager.bottleDistributionEnabled = true;
            objectiveText.text = ("Get your uncle \n some whiskey");
        }


    }

    public void RemoveObjective() {
        if (GameManager.CurrentObjective == 0)
        {
            objectiveText.text = ("Go talk to \n your mother");
            //highlight material/object
        }

        else if (GameManager.CurrentObjective == 1)
        {
            objectiveText.text = ("Go talk to \n your uncle");
            HubrechtBubble.enable();

            //highlight material/object
        }

        else if (GameManager.CurrentObjective == 2)
        {
            HubrechtBubble.disable();
            objectiveText.text = ("Turn on the radio");

            RadioBubble.enable();
            GameManager.radioInteractionEnabled = true;

            //highlight material/object
        }
        else if (GameManager.CurrentObjective == 3) {
            //fade to next level
            RadioBubble.disable();
        }

        else if (GameManager.CurrentObjective == 4)
        {
            //fade to next level
            Debug.Log("ENDED");
        }

        else {
            Debug.Log("Objective Error: its a feature");
        }

    }
}
