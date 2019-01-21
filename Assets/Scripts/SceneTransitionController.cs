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

    private Animator anim;

    void Start () {
        color = GetComponent<MeshRenderer>().material.color;
        anim = GetComponent<Animator>();
        material = GetComponent<Material>();



        StartAnimation();
    }

    private void FadeIn() {
        //color.a = Time.time - Mathf.Floor(Time.time);
    }

    public void StartAnimation(){
        anim.SetTrigger("fade");
        Debug.Log("FADE TRANSITION");
    }

    public void FadeToBlack()
    {
        anim.SetTrigger("fadeToBlack");
        Debug.Log("FADE To BLACK");
    }

}


