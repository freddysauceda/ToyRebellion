using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlySuper : MonoBehaviour {

    public string buttonName = "Select";
    public Transform origin;
    public float speed = 2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.LTouch))
        {
            //go forwards
            origin.position += Time.deltaTime * transform.forward * speed;
        }
    }
}
