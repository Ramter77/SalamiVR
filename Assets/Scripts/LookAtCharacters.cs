
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

public class LookAtCharacters : MonoBehaviour
{
    private Transform target;
    public float maxAngle = 35.0f;
    private Quaternion baseRotation;
    private Quaternion targetRotation;


    void Start()
    {
        baseRotation = transform.rotation;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {

        Vector3 look = target.transform.position - transform.position;
        look.y = 0;

        Quaternion q = Quaternion.LookRotation(look);
        if (Quaternion.Angle(q, baseRotation) <= maxAngle) { targetRotation = q;  }
            

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2.0f);
    }
}
