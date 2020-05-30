using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerNameHandler : NetworkBehaviour
{
    public GameObject nameController;
    public GameObject nameText;
    public string storedName;

    [SyncVar]
    public string playerName;



    [Command]
    public void CmdChangeName(string newName)
    {
        playerName = newName;
    }

    void Start()
    {
        if (isLocalPlayer)
        {
            nameController = GameObject.Find("NameManager");
            storedName = nameController.GetComponent<StartGame>().passedName;
            CmdChangeName(storedName);
        }
    }

    void Update()
    {
        if (nameText.GetComponent<TextMesh>().text != playerName)
        {
            nameText.GetComponent<TextMesh>().text = playerName;
        }
    }

}