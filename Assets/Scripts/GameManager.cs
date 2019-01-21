using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static bool Oculus;  //change this

    public int CurrentObjective = 0;  //level1: cigs, whiskey, radio
    public bool isCompleted = false;

    private PlaySong radioScript;

    private AudioSource sound;
    public AudioSource radioSong;
    private float radioSongCounter;

    //UI controller script
    private UIController UIController;

    [Header("Tassio Booleans")]
    [Tooltip("How many cigarette have to be distributed")]
    public int leftCigarettes;
    public static bool cigaretteDistributionEnabled = false;
    [Tooltip("How many cigarette have been distributed")]
    public int distributedCigarettes;

    public static bool bottleDistributionEnabled = false;
    [Tooltip("How many bottles have been distributed")]
    public int distributedBottles;

    public bool radioInteractionEnabled = false;

    public SceneTransitionController sceneTransitionController;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            incrementRadio();




            //Scene scene = SceneManager.GetActiveScene();
            //SceneManager.LoadScene(scene.name);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene(2);
        }
    }

    public void incrementCigarette()
    {
        distributedCigarettes++;
        leftCigarettes--;
        UIController.updateLeftCigarettes();

        if (distributedCigarettes > leftCigarettes)
        {
            //completed objective
            CompleteObjective();
            UIController.RemoveObjective();

            cigaretteDistributionEnabled = false;
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

            bottleDistributionEnabled = false;
        }
    }

    

    public void incrementRadio()
    {
        CompleteObjective();
        UIController.RemoveObjective();

        radioInteractionEnabled = false;



        sceneTransitionController = GameObject.FindGameObjectWithTag("SceneTransition").GetComponent<SceneTransitionController>();
        StartCoroutine(increasePitchandFade(1f));
        //sceneTransitionController.FadeToBlack();
    }

    private IEnumerator increasePitchandFade(float seconds) {        
        //if increased pitch 30 times: fadeToBlack
        while (radioSongCounter < 20)
        {
            //Fade delay
            yield return new WaitForSeconds(0.5f);
            incPitch();
            //StartCoroutine(increasePitch(0.1f));
        }

        StopAllCoroutines();
        sceneTransitionController.FadeToBlack();
    }

    private void incPitch()
    {
        radioSongCounter++;
        radioSong.pitch += 0.02f;
    }

    void Start()
    {
        //FADE IN SCREEN
        if (sceneTransitionController = null)
        {

            sceneTransitionController = GameObject.FindGameObjectWithTag("SceneTransition").GetComponent<SceneTransitionController>();
            sceneTransitionController.StartAnimation();
        }

        if (UIController == null)
        {
            UIController = GameObject.FindGameObjectWithTag("UI").GetComponent<UIController>();
        }

        if (radioScript == null)
        {
            radioScript = GameObject.FindGameObjectWithTag("Radio").GetComponent<PlaySong>();
        }

        sound = GetComponent<AudioSource>();
    }

    public void CompleteObjective()
    {
        CurrentObjective++;

        Debug.Log("Current objective: " + CurrentObjective);
        //Play completed sound
        sound.PlayOneShot(sound.clip);


        if (CurrentObjective == 1)
        {   //cigarettes
            //make speech bubble over bottle objective appear


        }
        else if (CurrentObjective == 2)
        {    //bottle

        }
    }
}