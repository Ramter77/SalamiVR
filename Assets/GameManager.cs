﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static bool Oculus;  //change this

    public static int CurrentObjective = 0; //radio, level 1
    public bool isCompleted = false;

    public PlaySong radioScript;


    [Header("Tassio Booleans")]
    [Tooltip ("How many cigarette have to be distributed")]
    public int leftCigarettes;
    [Tooltip("How many cigarette have been distributed")]
    public int distributedCigarettes;
    [Tooltip("How many bottles have been distributed")]
    public int distributedBottles;

    public void incrementCigarette() {
        distributedCigarettes++;
        if (distributedCigarettes > leftCigarettes) {
            //Execute public function on UI here that makes the objective text disappear

            //completed objective
            CompleteObjective();
        }
    }

    public void incrementBottle()
    {
        distributedBottles++;
        if (distributedBottles > 0)
        {
            //Execute public function on UI here that makes the objective text disappear

            //completed objective
            CompleteObjective();
        }
    }

    void Start () {
        if (radioScript == null)
        {
            radioScript = GameObject.FindGameObjectWithTag("Radio").GetComponent<PlaySong>();
        }
    }

    public void CompleteObjective()
    {
        CurrentObjective++;

        if (CurrentObjective == 1)
        {   //cigarettes

        }
        else if (CurrentObjective == 2)
        {    //bottle

        }
    }





    /*
    public void CheckObjective() {

        if (CurrentObjective == 1 && isCompleted == false) {

            radioScript.RadioSoundData.Play();
            isCompleted = true;
            CheckObjectiveCompletion();
            

        }

        }

    private void CheckObjectiveCompletion() {
        if (isCompleted == true) {
            CurrentObjective += 1;
            isCompleted = false;
            Debug.Log(CurrentObjective);
        }
        
    }
    */
}