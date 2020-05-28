using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNameHandler : MonoBehaviour
{
	public GameObject nameController;
    // Start is called before the first frame update
    void Start()
    {
        nameController = GameObject.Find("NameManager");
        GetComponent<TextMesh>().text = nameController.GetComponent<StartGame>().passedName;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
