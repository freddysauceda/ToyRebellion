using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPresser : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

        RaycastHit location_info;
        bool z = OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
        if (z)
        {
            if (Physics.Raycast(transform.position, transform.forward, out location_info))
            {
                if (location_info.collider.GetComponent<Button>())
                {
                    location_info.collider.GetComponent<Button>().OnPress();
                }
            }
        }
    }
}
