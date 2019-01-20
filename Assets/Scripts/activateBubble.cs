﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateBubble : MonoBehaviour {
    //This script activates the speech bubbles over the heads of ppl

	void Start () {
        disable();
    }

    public void enable()
    {
        gameObject.SetActive(true);
    }

    public void disable()
    {
        gameObject.SetActive(false);
    }
}
