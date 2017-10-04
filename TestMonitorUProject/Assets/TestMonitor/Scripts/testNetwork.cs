using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class testNetwork : MonoBehaviour {

	public NetworkManager _network;


	// Use this for initialization
	void Start () {
		_network.StartServer ();
		NetworkServer.RegisterHandler (TestMonitorMsgType.SetupScene, DemoHandler);
	}
	
	// Update is called once per frame
	void Update () {

			
	}

	void DemoHandler ( NetworkMessage getMsg ) {
		SceneSetupMessage sceneMsg;
		sceneMsg = getMsg.ReadMessage<SceneSetupMessage> ();

		Debug.Log (sceneMsg.bundleUrl);
	}
}
