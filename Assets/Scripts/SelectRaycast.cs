using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectRaycast : MonoBehaviour {

    public string FloorTag = "Floor";
    private ObjectSelector selector;

    void Start()
    {
        selector = GetComponent<ObjectSelector>();
    }

	// Update is called once per frame
	void Update () {
        RaycastHit location_info;
        bool z = OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
        if (z)
        {
            if (Physics.Raycast(transform.position, transform.forward, out location_info))
            {
                if (location_info.transform.GetComponent<Buyable>()) return;

                FriendlyAI sel = location_info.transform.GetComponent<FriendlyAI>();
                if (sel != null)
                {
                    selector.ToggleObject(sel);
                    return;
                }

                EnemyAI target = location_info.transform.GetComponent<EnemyAI>();
                if (target != null)
                {
                    AiAction attackOrder = new AiAction();
                    attackOrder.order = AiActionType.Attack;
                    attackOrder.target = target.transform;
                    selector.GiveOrder(attackOrder);
                    return;
                }


                if (FindBestObject()) return;

                
                if (location_info.transform.CompareTag(FloorTag))
                {
                    AiAction moveOrder = new AiAction();
                    moveOrder.order = AiActionType.Move;
                    moveOrder.targetPosition = location_info.point;
                    selector.GiveOrder(moveOrder);
                }
            }
        }
	}

    public float thresholdAngle = 0.97f;

    private FriendlyAI[] FriendlyList;
    private EnemyAI[] EnemyList;

    public bool FindBestObject()
    {
        FriendlyList = FindObjectsOfType<FriendlyAI>();
        EnemyList = FindObjectsOfType<EnemyAI>();

        Transform best=null;
        float bestAngle=thresholdAngle;


        foreach (EnemyAI eai in EnemyList)
        {
            float angle = Vector3.Dot((eai.transform.position - transform.position).normalized, transform.forward);
            if (angle > bestAngle)
            {
                best = eai.transform;
                bestAngle = angle;
            }
        }

        foreach (FriendlyAI fai in FriendlyList)
        {
            float angle = Vector3.Dot((fai.transform.position - transform.position).normalized, transform.forward);
            if (angle > bestAngle)
            {
                best = fai.transform;
                bestAngle = angle;
            }
        }

        if (bestAngle == thresholdAngle || best==null)
        {
            return false;
        }
        
        if (best.GetComponent<FriendlyAI>())
        {
            selector.ToggleObject(best.GetComponent<FriendlyAI>());
        }
        else if (best.GetComponent<EnemyAI>())
        {
            AiAction attackOrder = new AiAction();
            attackOrder.order = AiActionType.Attack;
            attackOrder.target = best.transform;
            selector.GiveOrder(attackOrder);
        }
        print("Saved by the func! " + bestAngle);

        return true;
    }
}
