using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {
	public AudioSource music;


	public static AudioManager Instance;

	void Awake(){
		Instance = this;
		music = gameObject.GetComponent<AudioSource> ();
	}

	public void StopMusic(){
		music.Stop ();
	}

	public void PlayMusic(){
		music.Play ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
