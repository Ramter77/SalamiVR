using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleModel : MonoBehaviour {

    private MeshRenderer cigModel;
    private smokingLoop smokingLoopScript;

    void Start () {
        smokingLoopScript = transform.parent.GetComponent<smokingLoop>();
        smokingLoopScript.enabled = false;

        cigModel = GetComponent<MeshRenderer>();
        cigModel.enabled = false;
    }
    
    public void enableModel()
    {
        cigModel.enabled = true;
        smokingLoopScript.enabled = true;
    }
	
}
