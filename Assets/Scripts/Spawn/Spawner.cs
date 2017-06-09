using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public DropPackage orderDronePrefab;

    public Transform[] waypointApproach;
    public Transform[] exitWaypoint;
    public Transform ItemToSpawn;

    public Transform localizedWaypoints;

    public float spawnInterval;
    private float spawnTimer;

    public bool oneTime = false;

    // Use this for initialization
    void Start () {
        if (localizedWaypoints) localizedWaypoints.position = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer < 0)
        {
            DropPackage orderDrone = Instantiate(orderDronePrefab, waypointApproach[0].position, Quaternion.LookRotation(waypointApproach[1].position - waypointApproach[0].position));
            orderDrone.Prep(waypointApproach, exitWaypoint, ItemToSpawn);

            spawnTimer = spawnInterval;

            if (oneTime) this.enabled = false;
        }
	}
}
