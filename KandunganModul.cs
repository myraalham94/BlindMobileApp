using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]

public class KandunganModul : MonoBehaviour {
	
	private AudioSource audiosource;
	public AudioClip MyAudio;

	private LevelManager levelmanager;

	// Use this for initialization
	void Start () {

		audiosource = GetComponent<AudioSource> ();
		audiosource.clip = MyAudio;
		audiosource.Play ();

		levelmanager = GetComponent<LevelManager> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void chooseModul1(){

		SceneManager.LoadScene ("Modul 1");
	}

	public void chooseModul2(){

		SceneManager.LoadScene ("Modul 2");




	}

	public void chooseModul3(){

		SceneManager.LoadScene ("Modul 3");
	}

	public void chooseModul4(){

		SceneManager.LoadScene ("Modul 4");
	}
}
