using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]

public class Modul2Content : MonoBehaviour {

	private AudioSource audiosource;
	public AudioClip MyAudio;
	private float duration;
	public float time;


	public GameObject PausePanel;
	public GameObject ToNextPageCanvas;


	void Start () {

		//DontDestroyOnLoad (transform.gameObject);


		audiosource = GetComponent<AudioSource> ();
		audiosource.clip = MyAudio;
		audiosource.Play ();
		duration = MyAudio.length; 

		StartCoroutine  (WaitForSound ());
		Time.timeScale = 1.0f; //to start the timer

		audiosource.time = PlayerPrefs.GetFloat ("Modul_2");//nak load audio yg dah save bila bukak je scene tu


	}


	void Update () {

		StartCoroutine  (WaitForSound ());

		if (Input.GetKeyDown (KeyCode.Mouse0)) 
		{
			audiosource.Pause ();
			PausePanel.SetActive (true);
			Time.timeScale = 0; //to stop the timer


		} 
		else if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			audiosource.Play ();
			PausePanel.SetActive (false);

		}

		Debug.Log (audiosource.time);//nk tahu audio tu pause masa bila

	}

	public void ChooseResume(){

		audiosource.Play ();
		PausePanel.SetActive (false);
		Time.timeScale = 1.0f; //kena letak kt resume supaya nak start balik timer yang kita stop tu

	}

	public void ChooseBookmark(){


		PlayerPrefs.SetFloat ("Modul_2", audiosource.time);//nak save/bookmark audio yg dah pause
		//Time.timeScale -= audiosource.time;

	}

	public void ChooseReplay(){

		PlayerPrefs.DeleteAll ();//delete all the bookmark/save data
		SceneManager.LoadScene("Start Modul 2");
		PausePanel.SetActive (false);



	}

	public void ChooseMainMenu(){

		SceneManager.LoadScene ("Main Menu");

	}

	IEnumerator WaitForSound(){

		float remainingtime = duration - audiosource.time;

		yield return new WaitForSeconds (remainingtime);
		ToNextPageCanvas.gameObject.SetActive(true);

	}

}
