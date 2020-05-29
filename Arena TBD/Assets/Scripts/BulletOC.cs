using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// BULLET ON COLLISION
public class BulletOC : MonoBehaviour
{
    public int dmg = 5;

    void OnTriggerEnter(Collider collision)
    {
        GameObject hit = collision.gameObject;
        PlayerHealthController health = hit.GetComponent<PlayerHealthController>();

        if (health != null)
        {
            if (hit.tag != "Host Player")
            {
                hit.GetComponent<Rigidbody>().AddForce(transform.forward * 500f);
                hit.GetComponent<Rigidbody>().AddForce(-transform.up * 100f);
                health.TakeDamage(dmg);
            }
        }
        Destroy(gameObject);
    }
}
