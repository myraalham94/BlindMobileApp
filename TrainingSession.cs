using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]

public class TrainingSession: MonoBehaviour {

	private AudioSource audiosource;
	public AudioClip MyAudio;

	public GameObject Training_1;
	public GameObject Training_2;


	// Use this for initialization
	void Start () {

		audiosource = GetComponent<AudioSource> ();
		audiosource.clip = MyAudio;
		audiosource.Play ();

	}

	// Update is called once per frame
	void Update () {


		if (Input.GetKeyDown (KeyCode.Mouse0)) 
		{

			Training_1.SetActive (true);
			audiosource.Stop ();

		}


	}

}
