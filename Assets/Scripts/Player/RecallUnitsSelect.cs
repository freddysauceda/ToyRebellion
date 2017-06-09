using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecallUnitsSelect : MonoBehaviour {

    // Use this for initialization
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
                if (location_info.collider.gameObject.name == "RecallButton")
                {
                    AiAction moveAction = new AiAction();
                    moveAction.order = AiActionType.Move;
                    moveAction.targetPosition = this.transform.position;
                    selector.GiveOrderAll(moveAction);
                }
            }
        }
    }
}
