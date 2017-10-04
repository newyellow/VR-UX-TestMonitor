using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DemoSendingServer : NetworkManager {

	bool isSendingEnd = false;
	public Texture2D streamedTexture;
	public Texture2D bigTexture;

	int toConnId = 0;

	// Use this for initialization
	void Start () {
		this.StartServer ();
		Debug.Log ("Server Start");

		streamedTexture = new Texture2D (64, 64);
		bigTexture = new Texture2D (Screen.width, Screen.height);
		StartCoroutine (SendTextureLoop ());
	}

	IEnumerator SendTextureLoop () {
		while (true) {
			yield return new WaitForSeconds (0.2f);

			if (NetworkServer.connections.Count > 0) {
				yield return new WaitForEndOfFrame ();
				bigTexture.ReadPixels (new Rect (0.0f, 0.0f, Screen.width, Screen.height), 0, 0, true);
				bigTexture.Apply ();

				// resize texture
				float addValue = 1.0f/64.0f;
				for (int y = 0; y < 64; y++) {
					for (int x = 0; x < 64; x++) {
						streamedTexture.SetPixel (x, y, bigTexture.GetPixelBilinear (x * addValue, y * addValue));
					}
				}
				streamedTexture.Apply ();
				// end resizing

				StreamingTextureMsg texMsg = new StreamingTextureMsg ();
				texMsg.textureData = streamedTexture.GetRawTextureData ();

				NetworkServer.SendToAll (TestMonitorMsgType.StreamTexture, texMsg);
			}

		}

	}

	void GetScreenMiniSize () {
		
	}
}
