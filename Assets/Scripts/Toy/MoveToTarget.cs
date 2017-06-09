using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToTarget : MonoBehaviour {

    public NavMeshAgent trackerPrefab;

    public NavMeshAgent agent;

    public Transform target;

    private Rigidbody rb;

    public float updatePathInterval = 1;
    private float updateTimer;

    public float moveForce = 5;
    public float rotationSpeed = 5;

    private Vector3 upVec = new Vector3(0, 0.25f, 0);

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start()
    {
        agent = Instantiate(trackerPrefab, transform.position, Quaternion.identity);
        if (target) agent.SetDestination(target.position);
    }

    public void StopMoving()
    {
        this.enabled = false;
    }

    public void StartMoving()
    {
        if (agent && target)
        {
            agent.transform.position = this.transform.position;
            agent.SetDestination(target.position);
            updateTimer = 0;
            this.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) { StopMoving(); return; }

        if (updateTimer > updatePathInterval)
        {
            //if ((agent.transform.position - transform.position).magnitude > 1)

            agent.transform.position = this.transform.position;
            agent.SetDestination(target.position);
            updateTimer = 0;
        }
        updateTimer += Time.deltaTime;


        Vector3 dir = (agent.transform.position - transform.position);
        if (dir.magnitude < 3f) dir = agent.transform.forward;


        if (target == null) { StopMoving(); return; }
        Vector3 directTarget = (target.position - transform.position);
        if (directTarget.magnitude < 3) dir = directTarget;
        dir = dir.normalized;

        if (!rb) rb = GetComponent<Rigidbody>();
        rb.AddForce(dir * moveForce);
        this.transform.forward = new Vector3(dir.x, 0, dir.z);
    }
}
