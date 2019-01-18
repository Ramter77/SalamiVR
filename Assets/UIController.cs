using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Text objectiveText;
    public GameManager GameManager;
    
	void Start () {
        GameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
	
    public void AddObjective(string name) {


        if (name == "Mother") {
            objectiveText.text = ("Distribute cigarettes \n around. \n Cigarettes left: " + GameManager.leftCigarettes.ToString());
            
        }


    }
}
