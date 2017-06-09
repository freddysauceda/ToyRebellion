using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPackage : MonoBehaviour {

    public Transform[] waypoint;

    public Transform[] exitWaypoint;

    public Rigidbody package;

    private bool exiting;

    public float dropDist;

    public float speed = 5;

    public int currentIndex;

    public float rotationSpeed = 2;
    
	// Use this for initialization
	void Start () {
		
	}

    public void Prep(Transform[] enter, Transform[] exit, Transform item)
    {
        waypoint = enter;
        exitWaypoint = exit;
        package.GetComponent<Package>().modelToOrder = item;
    }
	
	// Update is called once per frame
	void Update () {

        Transform dropPoint = (exiting) ? exitWaypoint[currentIndex] : waypoint[currentIndex];


        Vector3 airPos = new Vector3(this.transform.position.x, dropPoint.position.y, this.transform.position.z);
        if ((dropPoint.position - airPos).magnitude < dropDist)
        {
            currentIndex++;
            if (!exiting) {
                if (currentIndex == waypoint.Length)
                {
                    exiting = true;
                    currentIndex = 0;
                    Ship();
                }
            } else
            {
                if (currentIndex == exitWaypoint.Length)
                {
                    Destroy(this.gameObject);
                    return;
                }
            }
        } else
        {
            this.transform.forward = Vector3.Lerp(this.transform.forward, dropPoint.position - airPos, rotationSpeed * Time.deltaTime);
            this.transform.position += this.transform.forward * speed * Time.deltaTime;
        }
	}

    public void Ship()
    {
        if (!package) return;
        package.transform.SetParent(null);
        package.isKinematic = false;
        package = null;
    }
}
