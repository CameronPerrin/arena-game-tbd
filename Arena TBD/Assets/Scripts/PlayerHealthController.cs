using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class PlayerHealthController : NetworkBehaviour
{
	public int health = 100;
	public TMP_Text healthBox;
	public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    	if (!isLocalPlayer)
        {
            return;
        }
		healthBox.text = health.ToString();
		if(Input.GetMouseButtonDown(0)){
			health = health - 5; 
		}
		if(health <= 0){
			Destroy(player);
		}
    }

    void TakeDamage()
    {

    }
}
