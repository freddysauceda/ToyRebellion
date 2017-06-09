using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableObject : MonoBehaviour {

    public Transform hightlight;

    public bool isGroup = false;

    public bool wallMounted;

    public int index;

    void Start()
    {
        if (hightlight) hightlight.gameObject.SetActive(false);
    }

    public void Highlight(bool on)
    {
        if (hightlight) hightlight.gameObject.SetActive(on);
        SelectableObject[] list = GetComponentsInChildren<SelectableObject>(true);

        foreach (SelectableObject o in list)
        {
            if (o == this) continue;
            o.Highlight(on);
        }

        if (!on)
        {
            if (wallMounted)
            {
                RaycastHit hit;
                if (Physics.Raycast(this.transform.position, -1 * this.transform.forward, out hit))
                {
                    this.transform.position = hit.point;
                    this.transform.forward = hit.normal;
                }
            }
            else
            {
                RaycastHit hit;
                if (Physics.Raycast(this.transform.position, -1 * Vector3.up, out hit))
                {
                    this.transform.position = hit.point;
                }
            }
        }
    }
}
