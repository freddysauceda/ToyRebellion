using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buyable : MonoBehaviour {
    
    public GameObject highlightObject;
    public GameObject regularObject;

    public int index;

    void Start()
    {
 /*       regular = new Material[objectToHighlight.Length];
        for (int i = 0; i < objectToHighlight.Length; ++i)
        {
            regular[i] = objectToHighlight[i].material;
        }*/
    }

    public void Highlight(bool on)
    {
        if (highlightObject == null) return;
        if (on)
        {
            highlightObject.SetActive(true);
            regularObject.SetActive(false);
        } else
        {
            highlightObject.SetActive(false);
            regularObject.SetActive(true);
        }

        /*for (int i = 0; i < objectToHighlight.Length; ++i)
        {
            for (int j = 0; j < objectToHighlight[i].materials.Length; ++j)
            {
                print ("A");
                objectToHighlight[i].materials[j] = highlight;// (on) ? highlight : regular[i];
            }
        }*/
    } 
}
