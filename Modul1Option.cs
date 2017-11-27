using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]

public class Modul1Option : MonoBehaviour {

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

	public void chooseObjektifModul1(){

		SceneManager.LoadScene ("Instruction before Objektif Modul 1");
	}

	public void chooseStartModul1(){

		SceneManager.LoadScene ("Instruction before Start Modul 1");
	}
}
