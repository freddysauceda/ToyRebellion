using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CausesDamage : MonoBehaviour {

    public string enemyTag = "Enemy";
    public float dmg = 25;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag(enemyTag))
        {
            col.gameObject.GetComponent<Destructible>().Damage(dmg);
        }
    }
}
