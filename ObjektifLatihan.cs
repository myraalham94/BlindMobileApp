using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]

public class ObjektifLatihan : MonoBehaviour {

	private AudioSource audiosource;
	public AudioClip MyAudio;

	private float duration;
	public float time;

	public GameObject PausePanel;
	public GameObject ToKandunganModulPanel;


	// Use this for initialization
	void Start () {

		audiosource = GetComponent<AudioSource> ();
		audiosource.clip = MyAudio;
		audiosource.Play ();
		duration = MyAudio.length;

		StartCoroutine(WaitForSoundToFinish());
		Time.timeScale = 1.0f;

		audiosource.time = PlayerPrefs.GetFloat ("Objektif Latihan");
		
	}
	
	// Update is called once per frame
	void Update () {

		StartCoroutine(WaitForSoundToFinish());

		if (Input.GetKeyDown (KeyCode.Mouse0)) {

			audiosource.Pause ();
			PausePanel.SetActive (true);
			Time.timeScale = 0;

		} else if (Input.GetKeyDown (KeyCode.Mouse0)) {

			audiosource.Play ();
			PausePanel.SetActive (false);

		}
			
		Debug.Log (audiosource.time);
	}

	IEnumerator WaitForSoundToFinish(){

		float remainingtime = duration - audiosource.time;
		yield return new WaitForSeconds (remainingtime);
		ToKandunganModulPanel.SetActive (true);

	}

	public void pressToKandunganModul(){

		SceneManager.LoadScene ("Kandungan Modul");

	}

	public void chooseResume(){

		audiosource.Play ();
		PausePanel.SetActive (false);
		Time.timeScale = 1.0f;

	}

	public void chooseBookmark(){

		PlayerPrefs.SetFloat ("Objektif Latihan", audiosource.time);
	}

	public void chooseReplay(){

		PlayerPrefs.DeleteAll ();
		SceneManager.LoadScene ("Objektif Latihan");

	}

	public void chooseMenuUtama(){

		SceneManager.LoadScene ("Main Menu");
	}
}
