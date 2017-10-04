using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UserDataMsg : MessageBase {
	public Quaternion headRot;
	public Quaternion controllerRot;
	public Quaternion objRot;
	public Vector3 objPos;
}
