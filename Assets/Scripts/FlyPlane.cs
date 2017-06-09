using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyPlane : MonoBehaviour {

    public float speed = 2;
    public Transform origin;

    public Transform head;
    public Transform arm1;
    public Transform arm2;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 line = (arm1.position - arm2.position);
       // Vector3 rotationLine = Vector3.Cross(line, head.forward);
        float rotationSpeed = -1 * Vector3.Dot(line, head.up);



        origin.Rotate(head.forward, 100*rotationSpeed * Time.deltaTime);

        origin.position += Time.deltaTime * head.forward * speed;
    }
}
