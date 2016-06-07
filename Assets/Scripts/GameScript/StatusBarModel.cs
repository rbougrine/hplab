﻿using UnityEngine;
using System.Collections;

public class StatusBarModel : MonoBehaviour {

    public string username;
    public Login login;
    private GameObject logIn;
    public string Feedback = null;
    public int score;
    public string InfoStatusbar;
    private readonly string ip = "145.24.222.160";

    // Use this for initialization
    void Start () {

        login = login.GetComponent<Login>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}


    public Login Login
    {
        get
        {
            return login;
        }
    }

    public void Getinfo()
    {
   
        username = login.Username;

        string url = "http://" + ip + "/LoginAccount.php";

     
        WWWForm form = new WWWForm();
        form.AddField("Username", username);


        WWW www = new WWW(url, form);

        StartCoroutine(userInfo(www));



    }

    IEnumerator userInfo(WWW www)
    {
        yield return www;

        if (www.error != null)
        {

            Feedback = www.error;

        }
        else
        {
            // Information the database sends back when succesfully logged in 
            Feedback = www.text;

            // Retrieving parts of the information string from the datasbase 

            string[] position = Feedback.Split(',');
            InfoStatusbar = (position[0]);

            // Retrieve only score int from the database string www.text
            score = int.Parse(position[1]);
            Debug.Log("SCORE IS HIER VAN DE DB" + score);


        }
    }

}
