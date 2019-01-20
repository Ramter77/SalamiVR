using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogHelper : MonoBehaviour {

    public Transform[] options;

	void Start () {

       
        for (int i = 0; i < options.Length; i++) {
            options[i] = transform.GetChild(0).GetChild(i).gameObject.transform;
            options[i].gameObject.SetActive(false);
        }

    }

    public void Helper(int j) {
        Debug.Log(options[j]);
        options[j].gameObject.SetActive(true);

    }

}
