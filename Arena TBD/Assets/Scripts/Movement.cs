using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Movement : NetworkBehaviour
{
    public float moveSpeed = 5f;
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isLocalPlayer)
        {
            return;
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0, Space.World);
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0, Space.World);
        }
        if (Input.GetKey("w"))
        {
            transform.Translate(0, 0, moveSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(0, 0, -moveSpeed * Time.deltaTime, Space.World);
        }


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
}
