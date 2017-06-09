using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

    public Transform origin;

    public Transform face;

    Vector3 lastPosition;
    Vector3 velocityVec;

    public float swingThreshold=.1f;
    public float minThreshold = 0;

    public float cooldown = 1;
    private float timer;
    public bool ready;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 frameVel = transform.position - lastPosition;
        lastPosition = transform.position;
        velocityVec = (velocityVec + frameVel) / 2.0f;

        if (velocityVec.magnitude > swingThreshold && ready && timer<=0)
        {
            FindBestObject();
            timer = cooldown;
            ready = false;
        }
        if (timer > 0 ) timer -= Time.deltaTime;

        if (velocityVec.magnitude <= minThreshold)
        {
            ready = true;
        }
	}

    public bool FindBestObject()
    {
        EnemyAI[] EnemyList = FindObjectsOfType<EnemyAI>();

        Transform best = null;
        float bestAngle = -1;


        foreach (EnemyAI eai in EnemyList)
        {
            float angle = Vector3.Dot((eai.transform.position - face.position).normalized, face.forward);
            if (angle > bestAngle)
            {
                best = eai.transform;
                bestAngle = angle;
            }
        }

        if (bestAngle == -1 || best == null)
        {
            return false;
        }

        origin.position = best.position - (transform.position - origin.position) + 1*Vector3.up;
        best.GetComponent<Destructible>().Damage(1000);

        return true;
    }
}
