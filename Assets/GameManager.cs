using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static bool Oculus;  //change this

    public int CurrentObjective = 0; //radio, level 1
    public bool isCompleted = false;

    private PlaySong radioScript;
    public Text objectiveText; 


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
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }
    }
 

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