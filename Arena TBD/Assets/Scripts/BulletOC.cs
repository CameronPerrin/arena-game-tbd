using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// BULLET ON COLLISION
public class BulletOC : MonoBehaviour
{

    public int dmg = 5;

    void OnCollisionEnter(Collision collision)
    {
        GameObject hit = collision.gameObject;
        PlayerHealthController health = hit.GetComponent<PlayerHealthController>();

        if (health != null)
        {
            health.TakeDamage(dmg);
        }
        Destroy(gameObject);
    }
}
