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


        if (health != null && hit.tag == "Player")
        {   
                health.TakeDamage(dmg);
                //hit.GetComponent<Rigidbody>().AddForce(transform.forward * 500f);
                hit.GetComponent<Rigidbody>().AddForce(transform.up * 750f);
        }
        gameObject.transform.localScale = new Vector3(10f, 10f, 10f);
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        //Destroy(gameObject);
    }
}