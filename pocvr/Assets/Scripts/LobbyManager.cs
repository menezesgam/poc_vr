using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class LobbyManager : NetworkLobbyManager {

	// Use this for initialization
	void Start () {
        
        
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.G))
        {
            NetworkLobbyManager.singleton.StartServer();
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            NetworkLobbyManager.singleton.StartClient();
        }
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
