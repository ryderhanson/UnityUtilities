using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MessageHub : SingletonMonoBehaviour<MessageHub>
{
	private Dictionary<MessageHubType, List<Action<object>>> _actionMap = new Dictionary<MessageHubType, List<Action<object>>>();

	public void Subscribe(MessageHubType messageType, Action<object> callback)
	{
		List<Action<object>> actionList;
		if(!_actionMap.TryGetValue(messageType, out actionList))
		{
			actionList = new List<Action<object>> ();

			_actionMap.Add(messageType, actionList);
		}

		actionList.Add (callback);
	}

	public void Publish(MessageHubType messageType, object payload)
	{
		List<Action<object>> actionList;
		if(_actionMap.TryGetValue(messageType, out actionList))
		{
			foreach (Action<object> callback in actionList) 
			{
				if (callback != null) 
				{
					callback.Invoke (payload);
				}
			}
		}
			
	}
}
