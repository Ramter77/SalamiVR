using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleModel : MonoBehaviour {

    private MeshRenderer cigModel;

    void Start () {
        cigModel = GetComponent<MeshRenderer>();
        cigModel.enabled = false;
    }
    
    public void enableModel()
    {
        cigModel.enabled = true;
    }
	
}
