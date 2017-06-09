using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform origin;
    public float cooldown;
    public string floorTag = "Floor";
    public string buttonName = "blink_button_L";
    public bool left;

    private float current_timer;

    public void blink(Vector3 HitPos)
    {
        origin.position = HitPos;
    }

    void Update()
    {

        current_timer += Time.deltaTime;

        RaycastHit location_info;


        bool z = false;

        if (left) {
            z=OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch);
        } else {
            z=OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch);
        }

                if (z &&
            Physics.Raycast(this.transform.position, this.transform.forward, out location_info)
            && current_timer >= cooldown)
        {
            if (!location_info.transform.gameObject.CompareTag(floorTag)) return;
            blink(location_info.point);
            current_timer = 0.0f;
        }
    } 
}
