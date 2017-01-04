using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	[SerializeField]
	private AudioClip[] _audioClips = null;

	private Dictionary<string, AudioClip> _audioClipDictionary = new Dictionary<string, AudioClip> ();

	private AudioSource _audioSource = null;

	// Use this for initialization
	void Awake () 
	{
		foreach (AudioClip clip in _audioClips) 
		{
			_audioClipDictionary.Add(clip.name, clip);
		}

		_audioSource = GetComponent<AudioSource> ();
	}


	public void PlayClipOneShot(string name)
	{
		AudioClip clip;
		if (_audioClipDictionary.TryGetValue (name,out clip)) 
		{
			_audioSource.PlayOneShot (clip);
		} 
		else 
		{
			Debug.Log ("[AudioManager] Could not find audio clip of name: " + name);
		}
	}

	public void PlayClipLooping(string name)
	{
		AudioClip clip;
		if (_audioClipDictionary.TryGetValue (name, out clip)) 
		{
			_audioSource.loop = true;
			_audioSource.clip = clip;
			_audioSource.Play();
		} 
		else 
		{
			Debug.Log ("[AudioManager] Could not find audio clip of name: " + name);
		}
	}

	public void StopAllAudio()
	{
		_audioSource.Stop();
	}

	public void Pause()
	{
		_audioSource.Pause();
	}

	public void Resume()
	{
		_audioSource.UnPause();
	}
}
