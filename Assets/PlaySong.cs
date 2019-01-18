using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySong : MonoBehaviour {

    public GameManager GameManager;
    public AudioSource RadioSoundData;
    public bool isRadioPlaying = false;
    private bool RadioActivatedOnce = false;    

    void Start() {        
        if (GameManager == null)
        {
            GameManager = GameObject.FindGameObjectWithTag("Radio").GetComponent<GameManager>();
        }
        RadioSoundData = GetComponent<AudioSource>();
    }

    public void RadioToggle() {
        if (RadioActivatedOnce == false)
        {
            RadioActivatedOnce = true;

            GameManager.CompleteObjective();
            Debug.Log(RadioActivatedOnce);
        }

        if (RadioActivatedOnce == true)
        {
            if (isRadioPlaying == false)
            {
                RadioSoundData.Play();
                isRadioPlaying = true;
            }
            else if (isRadioPlaying == true)
            {
                RadioSoundData.Stop();
                isRadioPlaying = false;
            }
        }
    }
}
