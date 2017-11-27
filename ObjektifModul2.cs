using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]

public class ObjektifModul2 : MonoBehaviour {

	private AudioSource audiosource;
	public AudioClip MyAudio;

	private float duration;
	public float time;

	public GameObject PausePanel;
	public GameObject NextPanel;


	void Start () {

		audiosource = GetComponent<AudioSource> ();
		audiosource.clip = MyAudio;
		audiosource.Play ();
		duration = MyAudio.length; 

		StartCoroutine(WaitForSoundToFinish());
		Time.timeScale = 1.0f;

		audiosource.time = PlayerPrefs.GetFloat ("Objektif Modul 2");

	}


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
		NextPanel.SetActive (true);

	}

	public void ChooseSeterusnya(){ //go to start modul 1

		SceneManager.LoadScene ("Instruction before Start Modul 2");
	}

	public void chooseResume(){

		audiosource.Play ();
		PausePanel.SetActive (false);
		Time.timeScale = 1.0f;

	}

	public void chooseBookmark(){

		PlayerPrefs.SetFloat ("Objektif Modul 2", audiosource.time);
	}

	public void chooseReplay(){

		PlayerPrefs.DeleteAll ();
		SceneManager.LoadScene ("Objektif Modul 2");

	}

	public void chooseMenuUtama(){

		SceneManager.LoadScene ("Main Menu");
	}

}
