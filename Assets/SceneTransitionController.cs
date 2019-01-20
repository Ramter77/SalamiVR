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

    public int seconds;

    private Animation anim;

    void Start () {
        color = GetComponent<MeshRenderer>().material.color;
        anim = gameObject.GetComponent<Animation>();
        StartCoroutine(Timer());
    }

    private void FadeIn() {
        color.a = Time.time - Mathf.Floor(Time.time);

    }

    public void StartAnimation(){
        anim.Play("fade");
        Debug.Log("FADE TRANSITION");
    }
	
	
	void Update () {
		
	}

    IEnumerator Timer()
    {
        print(Time.time);
        yield return new WaitForSeconds(seconds);
        print(Time.time);
        StartAnimation();

    }
}


