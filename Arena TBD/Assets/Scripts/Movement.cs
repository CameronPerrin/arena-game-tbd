using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Movement : NetworkBehaviour
{
    public float moveSpeed = 5f;
    public float horizontalSpeed = 2.0f;
    public float verticalSpeed = 2.0f;
    public float jumpHeight = 2.0f;
    
    [HideInInspector]
    public Vector3 jump;
    [HideInInspector]
    public bool isGrounded;
    [HideInInspector]
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody>();
		jump = new Vector3(0.0f, 3.0f, 0.0f);
    }

	void OnCollisionStay(){
        isGrounded = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        // Player movement
        if (Input.GetKey("d"))
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0, Space.World);
        if (Input.GetKey("a"))
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0, Space.World);
        if (Input.GetKey("w"))
            transform.Translate(0, 0, moveSpeed * Time.deltaTime, Space.World);
        if (Input.GetKey("s"))
            transform.Translate(0, 0, -moveSpeed * Time.deltaTime, Space.World);

        if (Input.GetKey("space") && isGrounded){
        	// rb.AddForce(Vector3.up * 4.0f);
        	rb.AddForce(jump * jumpHeight, ForceMode.Impulse);
        	isGrounded = false;
        }
        if(!isGrounded && rb.velocity.y < 0f) // still jumping and falling
     	{
         	rb.AddForce(Vector3.down * 4.0f);
     	}

        // Camera Look
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); ;
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {

            Vector3 target = hit.point;
            target.y = 0;
            target.y = transform.localScale.y / 2f;

            transform.LookAt(new Vector3(target.x, transform.position.y, target.z));
        }
    }

    // Change player color
    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.yellow;
    }

}
