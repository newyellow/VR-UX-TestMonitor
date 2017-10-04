using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TestMonitorMsgType  {
	public static short PlayerData = MsgType.Highest + 1;
	public static short SetupScene = MsgType.Highest + 2;
	public static short StreamTexture = MsgType.Highest + 3;
}
