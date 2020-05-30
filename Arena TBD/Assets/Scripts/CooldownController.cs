using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownController : MonoBehaviour
{
	private float cooldownSeconds = 1f;
	public GameObject CdBar;


	[HideInInspector]
	private float speed;
	[HideInInspector]
	private float currentAmount= 0;
	

	void Start(){
		speed = 100 / cooldownSeconds;
	}

    // Update is called once per frame
    void Update()
    {
        if(currentAmount < 100){
        	currentAmount += speed*Time.deltaTime;
        }
        else if(Input.GetKeyDown(KeyCode.Mouse0))
        {
        	currentAmount = 0;
        }
        CdBar.GetComponent<Image>().fillAmount = currentAmount / 100;
    }
}
