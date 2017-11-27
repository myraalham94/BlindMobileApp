using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]

public class FirstPage : MonoBehaviour {

	private AudioSource audiosource;
	public AudioClip MyAudio;

	// Use this for initialization
	void Start () {

		audiosource = GetComponent<AudioSource> ();
		audiosource.clip = MyAudio;
		audiosource.Play ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void chooseTraining(){

		SceneManager.LoadScene ("Main Page Training Game");
	}

	public void chooseSkipTraining(){

		SceneManager.LoadScene ("Main Menu");
	}

}
