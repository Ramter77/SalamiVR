﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static bool Oculus;  //change this

    public int CurrentObjective = 0;  //level1: cigs, whiskey, radio
    public bool isCompleted = false;

    private PlaySong radioScript;
    public Text objectiveText;

    //UI controller script
    public UIController UIController;

    [Header("Tassio Booleans")]
    [Tooltip ("How many cigarette have to be distributed")]
    public int leftCigarettes;
    [Tooltip("How many cigarette have been distributed")]
    public int distributedCigarettes;
    [Tooltip("How many bottles have been distributed")]
    public int distributedBottles;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.name);
        }
    } 

    public void incrementCigarette() {
        distributedCigarettes++;
        leftCigarettes--;
        UIController.updateLeftCigarettes();

        if (distributedCigarettes > leftCigarettes) {
            //completed objective
            CompleteObjective();
            UIController.RemoveObjective();
        }
    }

    public void incrementBottle()
    {
        distributedBottles++;
        if (distributedBottles > 0)
        {
            //completed objective
            CompleteObjective();
            UIController.RemoveObjective();
        }
    }

    public void incrementRadio()
    {   
        CompleteObjective();
        UIController.RemoveObjective();
    }


    void Start () {
        
        if (UIController == null) {
            UIController = GameObject.FindGameObjectWithTag("UI").GetComponent<UIController>();
        }
        
        if (radioScript == null)
        {
            radioScript = GameObject.FindGameObjectWithTag("Radio").GetComponent<PlaySong>();
        }
    }

    public void CompleteObjective()
    {
        CurrentObjective++;


        //Play completed sound




        if (CurrentObjective == 1)
        {   //cigarettes
            //make speech bubble over bottle objective appear
        }
        else if (CurrentObjective == 2)
        {    //bottle

        }
    }
}