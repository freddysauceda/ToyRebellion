using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSelect : MonoBehaviour {

    public Savefile saver;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        bool z = OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
        if (z)
        {
            RaycastHit location_info;
            if (Physics.Raycast(transform.position, transform.forward, out location_info))
            {
                if (location_info.transform.gameObject.tag == "Save")
                saver.startSave();
            }
        }
    }
}
