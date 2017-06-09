using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapper : MonoBehaviour {

    public Transform prefabIcon1;
    public Transform prefabIcon2;

    private Transform[] icon1 = new Transform[100];
    private Transform[] icon2 = new Transform[100];

    public float MAX_X;
    public float MAX_Z;

    public void Start()
    {
        for (int i = 0; i < 100; ++i)
        {
            icon1[i] = Instantiate(prefabIcon1, this.transform.position, Quaternion.identity);
            icon1[i].transform.parent = this.transform;
        }
        for (int i = 0; i < 100; ++i)
        {
            icon2[i] = Instantiate(prefabIcon2, this.transform.position, Quaternion.identity);
            icon2[i].transform.parent = this.transform;
        }
    }

    // Update is called once per frame
    void Update () {
        Mappable[] blips = FindObjectsOfType<Mappable>();

        int ind1 = 0;
        int ind2 = 0;
        foreach (Mappable m in blips)
        {
            if (m.type == 0)
            {
                if (ind1 >= 100) continue;
                icon1[ind1].transform.localPosition = new Vector3(m.transform.position.x / MAX_X, 0, m.transform.position.z / MAX_Z);
                icon1[ind1].gameObject.SetActive(true);
                ind1++;
            } else
            {
                if (ind2 >= 100) continue;
                icon2[ind2].transform.localPosition = new Vector3(m.transform.position.x / MAX_X, 0, m.transform.position.z / MAX_Z);
                icon2[ind2].gameObject.SetActive(true);
                ind2++;
            }
        }
        for (; ind1 < 100; ++ind1)
        {
            icon1[ind1].gameObject.SetActive(false);
        }
        for (; ind2 < 100; ++ind2)
        {
            icon2[ind2].gameObject.SetActive(false);
        }
	}
}
