using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerNameHandler : NetworkBehaviour
{
    // public GameObject nameController = GameObject.Find("NameManager");
    [SyncVar (hook = "ChangeName")]
    public string playerName;

    void OnGUI()
    {
        if (!isLocalPlayer)
        {
            playerName = GUI.TextField(new Rect(25, Screen.height - 40, 100, 30), playerName);
            if (GUI.Button(new Rect(130, Screen.height - 40, 80, 30), "Change"))
            {
                GetComponent<TextMesh>().text = playerName;
            }
        }
    }

  
    public void ChangeName(string newName)
    {
        Debug.Log("Entered Name Change function");
        playerName = newName;
    }

    void Update()
    {
        if(isLocalPlayer)
        {
            GetComponent<TextMesh>().text = playerName;
        }
    }

}