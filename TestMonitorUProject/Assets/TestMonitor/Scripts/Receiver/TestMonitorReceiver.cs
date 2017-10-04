using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TestMonitorReceiver : MonoBehaviour {

	public string serverIP = "192.168.0.1";
	public int serverPort = 6666;

	NetworkClient _client;

	public Transform headObj;
	public Transform controllerObj;
	public Transform testObj;
	public Transform tableObj;

	// Use this for initialization
	void Start () {
		_client.RegisterHandler (TestMonitorMsgType.SetupScene, DoSetupScene);
		_client = new NetworkClient ();		
	}

	void DoSetupScene ( NetworkMessage msg ) {
		SceneSetupMsg sceneMsg = msg.ReadMessage<SceneSetupMsg> ();

		headObj.position = sceneMsg.headPos;
		controllerObj.position = sceneMsg.controllerPos;
		tableObj.position = sceneMsg.tablePos;
		testObj.position = sceneMsg.tablePos;
	}

	void GetUserData ( NetworkMessage msg ) {
		UserDataMsg userMsg = msg.ReadMessage<UserDataMsg> ();

		headObj.rotation = userMsg.headRot;
		controllerObj.rotation = userMsg.controllerRot;
		testObj.position = userMsg.objPos;
		testObj.rotation = userMsg.objRot;
	}
}
