using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [HideInInspector]
    static string theName;
    public string passedName;
    public GameObject inputField;
    // Start is called before the first frame update
    void Start()
    {
        passedName = theName;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(theName);
        //access nameManager from new script attached to the players new health text thing
        //apply that variable to the health text thing from earlier

    }

    public void goToLevel1()
    {
        Application.LoadLevel(1);
    }

    public void StoreName()
    {
        theName = inputField.GetComponent<Text>().text;
    }
}
