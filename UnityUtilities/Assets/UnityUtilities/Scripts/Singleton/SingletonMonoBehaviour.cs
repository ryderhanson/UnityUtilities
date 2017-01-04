using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : class	
{
	private static T _currentInstance = null;

	public static T Instance()
	{
		return _currentInstance;
	}

	private void Awake()
	{
		if(_currentInstance == null)
		{
			_currentInstance = this as T;
		}

		DontDestroyOnLoad (this);
	}
}
