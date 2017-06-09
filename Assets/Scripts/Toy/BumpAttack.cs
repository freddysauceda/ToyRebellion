using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumpAttack : MonoBehaviour
{

    public string enemyTag;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag(enemyTag) && (Vector3.Dot(col.contacts[0].normal, this.transform.forward) < -0.81 || Vector3.Dot(col.contacts[0].normal, Vector3.up) > 0.81))
        {
            if (col.gameObject.GetComponent<Destructible>())
            {
                col.gameObject.GetComponent<Destructible>().Damage(25);
            }
            else
            {
                Destroy(col.gameObject);
            }
        }

        Vector3 pushBackForce = col.contacts[0].normal;
        pushBackForce.y = 0;

        this.GetComponent<Rigidbody>().AddForce(pushBackForce * 2.5f, ForceMode.Impulse);
    }


    void OnCollisionStay(Collision col)
    {

        if (col.gameObject.CompareTag(enemyTag))
        {
            col.gameObject.GetComponent<Destructible>().Damage(1);
        }
    }
}
