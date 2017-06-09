using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hop : MonoBehaviour {

    public bool isHopping;

    public float hopForce = 2.5f;

    public float megaHopForce = 10;

    public float cooldown = 0.1f;
    private float cooldownTimer = 0;

    public int jumpNum;
    private int jumpsAvailable = 1;
    
    private Rigidbody rb;

    public Transform model;
    private Vector3 modelLocalPos;

    private bool modelHop;
    public float modelHopVel = 10;
    public float modelHopAccel = -100;
    private float modelHopTimer;

    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        modelLocalPos = model.localPosition;
    }

    void Update()
    {
        cooldownTimer -= Time.deltaTime;


        float newHeight=0;
        if (modelHop)
        {
            modelHopTimer += Time.deltaTime;
            newHeight = 0 + modelHopVel * modelHopTimer + modelHopAccel * (modelHopTimer * modelHopTimer);
            if (newHeight < 0) { newHeight = 0; modelHop = false; }
            model.localPosition = modelLocalPos + new Vector3(0, newHeight, 0);
        }
    }


    void OnCollisionStay(Collision other)
    {
        if (Vector3.Dot(Vector3.up, other.contacts[0].normal) > 0.5f)
        {
            if (isHopping && cooldownTimer <= 0)
            {
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                rb.AddForce(hopForce * Vector3.up, ForceMode.Impulse);
                cooldownTimer = cooldown;

                if (!modelHop) { 
                    modelHop = true;
                modelHopTimer = 0;
                }
            }
        }
    }
}
