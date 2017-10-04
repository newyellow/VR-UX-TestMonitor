using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DemoTextureCatcher : MonoBehaviour {

	public NetworkClient _client;
	public string serverIP = "192.168.0.1";
	public int serverPort = 6666;


	public Texture2D _texture;
	public MeshRenderer _renderer;

	void Start () {
		_texture = new Texture2D (64, 64);
		_client = new NetworkClient ();
		_client.RegisterHandler (TestMonitorMsgType.StreamTexture, GetTextureData);
	}


	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.Q)) {
			_client.Connect (serverIP, serverPort);
		}

		if (Input.GetKeyDown (KeyCode.W)) {
			Debug.Log ("is Connected: " + _client.isConnected);
		}

	}


	void GetTextureData ( NetworkMessage msg ) {
		StreamTextureMsg texMsg = msg.ReadMessage<StreamTextureMsg> ();

		_texture.LoadRawTextureData (texMsg.textureData);
		_texture.Apply ();

		_renderer.material.mainTexture = _texture;
	}
}
