using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    public static int CurrentObjective = 1; //radio, level 1
    public static bool isCompleted = false;





    [Header ("Tassio Booleans")]
    public int distributedCigarettes;
    public void incrementCigarette() {
        if (distributedCigarettes > 2) {
            //completed objective
            //Execute public function on UI here that makes the objective text disappear
        }
        else {
            distributedCigarettes++;
        }
    }





    //level 1

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public static void CheckObjective() {

        if (CurrentObjective == 1 && isCompleted == false) {

            PlaySong.RadioSoundData.Play();
            isCompleted = true;
            CheckObjectiveCompletion();
            

        }

        }

    private static void CheckObjectiveCompletion() {
        if (isCompleted == true) {
            CurrentObjective += 1;
            isCompleted = false;
            Debug.Log(CurrentObjective);
        }
        
    }



    }


