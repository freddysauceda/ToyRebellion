using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopper : MonoBehaviour {

    public string buttonName = "Select";

    public Buyable currentlyShopped;

    public Transform[] prefablist;

    private ObjectSelector selector;

    public int whiteboardIndex = 5;

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
                Buyable buy = location_info.transform.GetComponent<Buyable>();
                if (buy != null)
                {
                    Purchase(buy);
                    return;
                }


                if (currentlyShopped)
                {
                    //check if slightly off (like hit the map) -> return
                    if (currentlyShopped.index != whiteboardIndex)
                    {
                        if (!location_info.transform.gameObject.CompareTag("Floor")) return;
                    }
                    else
                    {
                        if (!location_info.transform.gameObject.CompareTag("Wall")) return;
                    }

                    Acquire(location_info);
                }           
            }
        }
    }

    //Select item & side effects (e.g. highlight)
    void Purchase(Buyable buy)
    {
        //deselect old one if exists
        if (currentlyShopped) currentlyShopped.Highlight(false);

        currentlyShopped = buy;
        currentlyShopped.Highlight(true);
    }

    void Acquire(RaycastHit location_info)
    {
        Vector3 location = location_info.point;
        Transform createdObject = Instantiate(prefablist[currentlyShopped.index], location, Quaternion.identity);

        if (currentlyShopped) currentlyShopped.Highlight(false);
        currentlyShopped = null;
    }
}
