using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package : MonoBehaviour {

    public Transform modelToOrder;
    private Animation openAnim;
    private Transform spawnedObject;

    private bool opening = false;

    public float spawnCountDown = 0.75f;

	// Use this for initialization
	void Start () {
        openAnim = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (opening && spawnCountDown > 0)
        {

            if (spawnedObject.GetComponent<MoveToTarget>() != null)
            {
                spawnCountDown -= Time.deltaTime;
                if (spawnCountDown < 0)
                {
                    spawnedObject.GetComponent<MoveToTarget>().enabled = true;
                    spawnedObject.GetComponent<Hop>().enabled = true;
                }
            }
        }
	}

    void OnCollisionStay(Collision other)
    {
        if (!opening && Vector3.Dot(other.contacts[0].normal, Vector3.up) > 0.81f)
        {
            this.GetComponent<BoxCollider>().enabled = false;
            Destroy(this.GetComponent<Rigidbody>());

            spawnedObject = Instantiate(modelToOrder, this.transform.position, Quaternion.identity);

            if (spawnedObject.GetComponent<MoveToTarget>() != null)
            {

                spawnedObject.GetComponent<MoveToTarget>().enabled = false;
                spawnedObject.GetComponent<Hop>().enabled = false;
            }

            openAnim.Play();
            GetComponent<DeleteAfter>().enabled = true;
            opening = true;
        }
    }
}
