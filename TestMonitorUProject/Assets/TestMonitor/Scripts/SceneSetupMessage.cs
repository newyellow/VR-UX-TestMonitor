using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SceneSetupMessage : MessageBase {
	public string bundleUrl;

	public Vector3 headPos;
	public Vector3 controllerPos;
	public Vector3 tablePos;
}
