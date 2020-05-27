using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject mainCam;
    public float xPosition, yPosition, zPosition;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        cameraMove();
    }

    private void cameraMove()
    {
        mainCam.transform.position = this.transform.position + new Vector3(xPosition, yPosition, -zPosition);
        mainCam.transform.LookAt(this.transform.position);
    }
}
