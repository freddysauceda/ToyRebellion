using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMap : MonoBehaviour {

    public GameObject Map;

    public bool active;

	// Use this for initialization
	void Start () {
        Map.SetActive(false);
	}

    // Update is called once per frame
    void Update()
    {
        RaycastHit location_info;
        bool z = OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
        if (z)
        {
            if (!active)
            {
                if (Physics.Raycast(transform.position, transform.forward, out location_info))
                {
                    if (location_info.collider.gameObject.name == "MapButton")
                    {
                        active = true;
                        Map.SetActive(active);
                    }
                }
            } else
            {
                active = false;
                Map.SetActive(active);
            }
        }
    }
}
