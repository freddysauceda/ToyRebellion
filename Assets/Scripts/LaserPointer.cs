using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : MonoBehaviour {

    public Transform laserStart;
    public LineRenderer laser;

    public Color[] colorList;

    public string floorTag = "Floor";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        laser.SetPosition(0, laser.transform.position);

        RaycastHit location_info;
        if (Physics.Raycast(transform.position, transform.forward, out location_info))
        {
            laser.SetPosition(1, location_info.point);

            SelectableObject sel = location_info.transform.GetComponent<SelectableObject>();
            if (sel != null)
            {
                setLaserColor(colorList[1]);
                return;
            }

            Buyable sel2 = location_info.transform.GetComponent<Buyable>();
            if (sel2 != null)
            {
                setLaserColor(colorList[2]);
                return;
            }

            if (location_info.transform.gameObject.CompareTag(floorTag))
            {
                setLaserColor(colorList[3]);
                return;
            }

            setLaserColor(colorList[0]);
        } else
        {
            laser.SetPosition(1, laser.transform.position + 10 * transform.forward);
            setLaserColor(colorList[0]);
        }
    }



    private void setLaserColor(Color c)
    {
        float emission = 3.2f;
        Color baseColor = c;
        Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);
        laser.material.SetColor("_EmissionColor", finalColor);
    }
}
