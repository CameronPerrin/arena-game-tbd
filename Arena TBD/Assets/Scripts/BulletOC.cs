using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

// BULLET ON COLLISION
public class BulletOC : NetworkBehaviour
{

    public int dmg = 5;

    void OnTriggerEnter(Collider collision)
    {
        GameObject hit = collision.gameObject;
        PlayerHealthController health = hit.GetComponent<PlayerHealthController>();

        hit.GetComponent<Rigidbody>().AddForce(transform.forward * 500f);
        hit.GetComponent<Rigidbody>().AddForce(-transform.up * 100f);

        if (health != null)
        {
            if (isLocalPlayer)
            {
                health.TakeDamage(dmg);
            }
        }
        Destroy(gameObject);
    }
}
