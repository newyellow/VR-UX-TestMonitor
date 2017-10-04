using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPixels : MonoBehaviour {

	public Texture2D _temp;

	// Use this for initialization
	void Start () {
		_temp = new Texture2D (512, 512);
		StartCoroutine (UpdateTexture ());
	}
	
	// Update is called once per frame


	IEnumerator UpdateTexture () {
		while (true) {
			yield return new WaitForSeconds (0.1f);



			yield return new WaitForEndOfFrame ();
			_temp.ReadPixels (new Rect (0.0f, 0.0f, Screen.width, Screen.height), 0, 0, true);
			_temp.Apply ();


		}
	}
}
