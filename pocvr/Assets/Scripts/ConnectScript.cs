﻿using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ConnectScript : NetworkManager {

    public GameObject playerprefab;

	// Use this for initialization
	void Start () {
        
        
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.G))
        {
            NetworkManager.singleton.StartServer();
        }else if (Input.GetKeyDown(KeyCode.L))
        {
            NetworkManager.singleton.StartClient();
        }
	}

    void StartMyServer()
    {
        StartServer();
    }

    public override void  OnStartServer()
    {
        print("Server");
    }

    public override void OnStartClient(NetworkClient client)
    {
        print("client");
    }


}
