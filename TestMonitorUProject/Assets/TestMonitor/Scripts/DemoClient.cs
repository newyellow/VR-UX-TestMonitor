using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DemoClient : MonoBehaviour {

	NetworkClient _client;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Z)) {
			_client = new NetworkClient ();
			_client.Connect ("127.0.0.1", 6666);
		}

		if (Input.GetKeyDown (KeyCode.X)) {
			Debug.Log (_client.isConnected);
		}

		if (Input.GetKeyDown (KeyCode.C)) {
			//_client.send
			SceneSetupMessage msg = new SceneSetupMessage();
			msg.bundleUrl = "qqq";
			msg.controllerPos = Vector3.one;
			msg.headPos = Vector3.one;
			msg.tablePos = Vector3.one;

			_client.Send (TestMonitorMsgType.SetupScene, msg);

			Debug.Log ("SENT");
		}
	}
}
