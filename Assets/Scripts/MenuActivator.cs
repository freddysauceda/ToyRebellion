using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuActivator : MonoBehaviour {

    public Transform menu;
    public string buttonName;

    private GameObject menuObject;

	public Transform laser;

    public GameObject subMenu;

	// Use this for initialization
	void Start () {
        menuObject = menu.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        //menuObject.SetActive(Input.GetButton(buttonName));
        //laser.gameObject.SetActive(Input.GetButton(buttonName));
        bool z = OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch);
        menuObject.SetActive(z);
        if (!z) subMenu.SetActive(false);
        laser.gameObject.SetActive(!z);
    }
}
