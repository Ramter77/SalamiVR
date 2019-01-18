using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySong : MonoBehaviour {
    public static AudioSource RadioSoundData;
    public static bool isRadioPlaying = false;
    private bool RadioActivatedOnce = false;

    // Use this for initialization
    void Start() {

        RadioSoundData = GetComponent<AudioSource>();
        
    }

	
	// Update is called once per frame
	void Update () {
		
	}

    public void RadioActivate() {

        if (RadioActivatedOnce == false)
        {
            GameManager.CheckObjective();
            RadioActivatedOnce = true;
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
