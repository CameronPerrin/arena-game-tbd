using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CameraController : NetworkBehaviour
{
    private GameObject mainCam;
    public float xPosition, yPosition, zPosition;
    public float offset;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        cameraMove();
    }

    private void cameraMove()
    {
        mainCam.transform.position = this.transform.position + new Vector3(xPosition, yPosition, (-zPosition-offset));

        mainCam.transform.LookAt((this.transform.position - new Vector3(0,0,offset)));
    }
}
