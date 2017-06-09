using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFadeOut : MonoBehaviour {

    public Light light;
    public float fadeRate = 0.95f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        light.intensity *= fadeRate;
	}
}
