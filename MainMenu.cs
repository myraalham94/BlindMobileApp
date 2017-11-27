using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]

public class MainMenu : MonoBehaviour {

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

	public void chooseObjektifLatihan(){

		SceneManager.LoadScene ("Instruction before Objektif Latihan");
	}

	public void chooseKandunganModul(){

		SceneManager.LoadScene ("Kandungan Modul");
	}

	public void chooseUjianAwalLatihan(){

		SceneManager.LoadScene ("Ujian Awal Latihan");
	}

	public void chooseExit(){

		SceneManager.LoadScene ("First Page");
	}
}
