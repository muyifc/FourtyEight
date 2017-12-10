using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	private static AudioManager _instance;
	public static AudioManager Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new AudioManager();
			}
			return _instance;
		}
	}

	public void StopMusic(){
		gameObject.transform.GetComponent<AudioSource> ().Stop ();
	}

	public void PlayMusic(){
		gameObject.transform.GetComponent<AudioSource> ().Play ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
