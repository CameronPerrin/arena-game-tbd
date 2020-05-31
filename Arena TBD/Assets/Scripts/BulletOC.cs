using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

// BULLET ON COLLISION
public class BulletOC : NetworkBehaviour
{
    public GameObject impactVFX;
    public int dmg = 5;
    public float tiltAroundX;
    public float tiltAroundZ;
    public float tiltAroundY;
    public bool doExpand = false; 
    public bool doShrink = false; 
    void OnTriggerEnter(Collider collision)
    {
        GameObject hit = collision.gameObject;
        PlayerHealthController health = hit.GetComponent<PlayerHealthController>();

        // When this collides with something, spawn VFX
        Instantiate(impactVFX, new Vector3(transform.position.x, transform.position.y + 0.6f, transform.position.z), transform.rotation);

        if (health != null && hit.tag == "Player")
        {   
                health.TakeDamage(dmg);
                //hit.GetComponent<Rigidbody>().AddForce(transform.forward * 500f);
                hit.GetComponent<Rigidbody>().AddForce(transform.up * 750f);
        }
        //gameObject.transform.localScale = new Vector3(8f, 8f, 8f);
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        doExpand = true;

        //Destroy(gameObject);
    }

    void Update(){

        //tiltAroundX += 2;
        //tiltAroundZ += 8;
        tiltAroundY += 8;
        //rotationVector.z += 0;
        Quaternion target = Quaternion.Euler(tiltAroundX, tiltAroundY, tiltAroundZ);
        gameObject.transform.rotation = target;
        expandDong();
    }

    void expandDong(){
        if(doExpand){
            gameObject.transform.localScale += new Vector3(0.3f, 0.3f, 0.3f);
        }
        if(gameObject.transform.localScale.x > 10f){
            doExpand = false;
            doShrink = true;
        }
        if(doShrink){
            gameObject.transform.localScale -= new Vector3(0.03f, 0.03f, 0.03f);
        }
    }
}