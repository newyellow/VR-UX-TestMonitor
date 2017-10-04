using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TestAppServer : NetworkManager {
	Camera testCam;

	// Use this for initialization
	void Start () {
		this.StartServer ();
	}

	public override void OnClientConnect (NetworkConnection conn)
	{
		//conn.Send ();
	}
}
