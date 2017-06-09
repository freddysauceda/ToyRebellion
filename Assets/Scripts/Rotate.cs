using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public float speed = 2.5f;
    public Vector3 axis = new Vector3(0,1,0);

	// Use this for initializatiom
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(axis, Time.deltaTime * speed);
	}
}
