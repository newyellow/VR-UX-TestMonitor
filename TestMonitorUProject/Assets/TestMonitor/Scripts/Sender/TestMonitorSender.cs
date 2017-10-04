using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TestMonitorSender : NetworkManager {
	
	void StartMonitor () {
		this.StartServer ();
		StartCoroutine (SendingData ());
	}

	// sending data
	void ClientCallForSetupScene (NetworkMessage msg) {

		// get data
		SceneSetupMsg sceneMsg = new SceneSetupMsg ();
		sceneMsg.assetId = DataCarrier._instance.nowAssetId;
		sceneMsg.controllerPos = TestSceneManager._instance.userController.position;
		sceneMsg.headPos = TestSceneManager._instance.userHead.position;
		sceneMsg.tablePos = RoomSetManager._instance.itemDesktopPosition.position;

		// send
		NetworkServer.SendToClient (msg.conn.connectionId, TestMonitorMsgType.SetupScene, sceneMsg);
	}

	IEnumerator SendingData () {
		UserDataMsg dataMsg = new UserDataMsg ();
		Transform userController = TestSceneManager._instance.userController;
		Transform userHead = TestSceneManager._instance.userHead;
		Transform testObj = TestSceneManager._instance.uxTestObject.transform;

		while (true) {
			yield return new WaitForSeconds (0.05f);

			if (NetworkServer.connections.Count > 0) {	
				dataMsg.controllerRot = userController.rotation;
				dataMsg.headRot = userHead.rotation;
				dataMsg.objPos = testObj.position;
				dataMsg.objRot = testObj.rotation;

				NetworkServer.SendToAll (TestMonitorMsgType.StreamUserData, dataMsg);
			}
		}
	}
}
