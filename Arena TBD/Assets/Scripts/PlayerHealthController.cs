using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class PlayerHealthController : NetworkBehaviour
{
	public int health;
	public TMP_Text healthBox;
	public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
    	health = 100;
    }

    // Update is called once per frame
    void Update()
    {
    	if(!isServer){
    		return;
    	}
		healthBox.text = health.ToString();
		TakeDamage();
		if(health <= 0){
			Destroy(player);
		}
    }

    void TakeDamage()
    {	


		if(Input.GetMouseButtonDown(0)){
			health -= 5; 
		}
    }
}
