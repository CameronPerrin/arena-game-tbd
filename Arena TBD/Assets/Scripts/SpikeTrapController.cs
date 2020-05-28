using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapController : MonoBehaviour
{
	Material m_Material;
	[HideInInspector]
	GameObject player;
    // Start is called before the first frame update
    void Start()
    {
		//Fetch the Material from the Renderer of the GameObject
    	m_Material = GetComponent<Renderer>().material;
        
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
            //Debug.Log("TRAPPED!");

            //switch to spike up version
            m_Material.color = Color.red;
        }
    }
    void OnCollisionExit(Collision collision)
    {
    	//switch to spike down version
    	m_Material.color = Color.blue;
    }

}
