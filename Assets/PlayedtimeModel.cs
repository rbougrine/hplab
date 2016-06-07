﻿using UnityEngine;
using System.Collections;
using System;

public class PlayedtimeModel : MonoBehaviour {

    public DateTime starttime, endtime;
    private string Username;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // Sending the score bacck to database with including username and score
    public void SendInfo()
    {
        Playedtime timer = GameObject.Find("Timer").GetComponent<Playedtime>();
        Username = timer.Username;
        starttime = timer.starttime;
        endtime = timer.endtime;

        // php file from server where savingtime is processing
        string url = "http://145.24.222.160/saveTime.php";

        WWWForm form = new WWWForm();

        form.AddField("username", Username);
        form.AddField("startime", starttime.ToLongTimeString());
        form.AddField("endtime", endtime.ToLongTimeString());
        WWW www = new WWW(url, form);

        StartCoroutine(saveInfo(www));

    }

    IEnumerator saveInfo(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error != null)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Debug.Log(www.text + "saveInfo");
        }

    }


}
