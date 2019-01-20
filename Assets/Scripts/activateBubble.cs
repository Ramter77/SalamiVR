using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateBubble : MonoBehaviour {

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
