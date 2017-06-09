using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyAI : MonoBehaviour {

    public AiAction defaultOrder;
    public AiAction currentOrder;

    private MoveToTarget mover;

    public Transform targetFlagPrefab;
    private Transform targetFlag;

    public GameObject highlightObject;

    public float rushObjDist = 5;
    public float enemyCheckRadius = 5;
    public string enemyTag = "Enemy";
    public float attackDistance = 3;

    // Use this for initialization
    void Start()
    {
        defaultOrder.target = FindObjectOfType<PlayerBase>().transform;

        mover = GetComponent<MoveToTarget>();

        targetFlag = Instantiate(targetFlagPrefab, this.transform.position, Quaternion.identity);
        targetFlag.gameObject.SetActive(false);

        SetOrder(defaultOrder);
    }

    // Update is called once per frame
    void Update()
    {

        if (currentOrder.target == null) { SetOrder(defaultOrder); }

        float targetDistance = (currentOrder.target.position - transform.position).magnitude;

        switch (currentOrder.order)
        {
            case AiActionType.Attack:

                break;
            case AiActionType.Move:

                break;
            case AiActionType.Capture:
               /* if (targetDistance > rushObjDist)
                {
                    //check enemies if still a bit off
                    Collider[] checkList = Physics.OverlapSphere(this.transform.position, enemyCheckRadius);
                    foreach (Collider c in checkList)
                    {
                        if (c.CompareTag(enemyTag))
                        {
                            AiAction attackOrder = new AiAction();
                            attackOrder.order = AiActionType.Attack;
                            attackOrder.target = c.transform;
                            SetOrder(attackOrder);
                            break;
                        }

                    }
                }*/



                break;
        }
    }

    public void SetOrder(AiAction order)
    {
        print("ORDER");
        targetFlag.gameObject.SetActive(false);
        currentOrder = order;

        switch (currentOrder.order)
        {
            case AiActionType.Attack:
                mover.target = currentOrder.target;
                break;
            case AiActionType.Move:
                print("MOVING");
                targetFlag.gameObject.SetActive(true);
                currentOrder.target = targetFlag;
                targetFlag.position = currentOrder.targetPosition;
                mover.target = currentOrder.target;
                break;
            case AiActionType.Capture:
                mover.target = currentOrder.target;
                break;
        }
        mover.StartMoving();
    }

    public void Highlight(bool isLit)
    {
        highlightObject.SetActive(isLit);
    }
}
