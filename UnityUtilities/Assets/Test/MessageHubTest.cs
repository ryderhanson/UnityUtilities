using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageHubTest : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		MessageHub.Instance().Subscribe(MessageHubType.BaseMessage, TestMessage);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			MessageHub.Instance ().Publish (MessageHubType.BaseMessage, "TestMessage");
		}
	}

	void TestMessage(object message)
	{
		string sentmessage = message as string;

		Debug.Log (sentmessage);
	}
}
