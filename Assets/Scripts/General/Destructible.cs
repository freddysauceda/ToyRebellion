using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {

    public float Hp=100;
    public Transform prefabRemains;

	public void Damage(float damage)
    {
        Hp -= damage;
        if (Hp < 0)
        {
            Destroy();
        }
    }

    public void Destroy()
    {
        if (prefabRemains) Instantiate(prefabRemains, this.transform.position, Quaternion.identity);

        Destroy(this.gameObject);
    }
}
