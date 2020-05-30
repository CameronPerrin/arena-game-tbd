using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


// BULLET ON COLLISION
public class BulletOC : NetworkBehaviour
{
    public int dmg = 5;
    public float tiltAroundX;
    public float tiltAroundZ;
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

    void Update(){
        tiltAroundX += 2;
        tiltAroundZ += 2;
        //rotationVector.z += 0;
        Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);
        gameObject.transform.rotation = target;
    }
}