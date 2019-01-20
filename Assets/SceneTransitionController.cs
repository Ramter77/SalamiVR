using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneTransitionController : MonoBehaviour {

    public Text YearText;
    public Text LocationText;
    public Text EventTypeText;
    private Material material;
    private Color color;

    private bool fade = true;
    private bool firstText = false;
    private bool SecondText = false;
    private bool ThirdText = false;

    void Start () {
        color = GetComponent<MeshRenderer>().material.color;
        StartCoroutine(Timer());
        
    }

    private void FadeIn() {
        color.a = Time.time - Mathf.Floor(Time.time);

    }
	
	
	void Update () {
		
	}

    IEnumerator Timer()
    {
        if (fade) {
            //print(Time.time);
            yield return new WaitForSeconds(5);
            
            //print(Time.time);
            FadeIn();
            
        }

    }
}


