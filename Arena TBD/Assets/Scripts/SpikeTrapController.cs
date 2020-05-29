using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapController : MonoBehaviour
{
	Animation spikeAnim;
	[HideInInspector]
	GameObject player;
    // Start is called before the first frame update
    void Start()
    {
		//Fetch the Material from the Renderer of the GameObject
    	spikeAnim = GetComponent<Animation>();
        //spikeAnim.speed = 5;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Player")
        {
        	player = collision.gameObject;
        	player.GetComponent<PlayerHealthController>().TakeDamage(20);
            player.GetComponent<Rigidbody>().AddForce(transform.up * 1000f);
            //Debug.Log("TRAPPED!");

            //switch to spike up version
            spikeAnim.Play("Anim_TrapNeedle_Show");
        }
    }
    void OnCollisionExit(Collision collision)
    {
    	//switch to spike down version
    	spikeAnim.Play("Anim_TrapNeedle_Hide");
    }

}
