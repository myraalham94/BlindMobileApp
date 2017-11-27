using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]

public class FinishModul : MonoBehaviour {

	private AudioSource audiosource;
	public AudioClip MyAudio;
	private float duration;
	public float time;

	//public GameObject NextPanel;
	public GameObject ModulContentCanvas;

	public static int releasedModulStatic = 1;
	public int releasedModul;
	public string NextModul;

	void Awake () {

		ModulContentCanvas.gameObject.SetActive (false);

		audiosource = GetComponent<AudioSource> ();
		audiosource.clip = MyAudio;
		audiosource.Play ();
		duration = MyAudio.length; 

		//StartCoroutine  (WaitForSound ());

		if (PlayerPrefs.HasKey ("Modul")) 
		{
			releasedModulStatic = PlayerPrefs.GetInt ("Modul", releasedModulStatic);
		}

	}
		

	void Update () {

	}

	//IEnumerator WaitForSound(){

		//yield return new WaitForSeconds (duration);
		//NextPanel.gameObject.SetActive(true);

	//}

	public void ChooseNextModul(){

		//SceneManager.LoadScene (8);
		SceneManager.LoadScene(NextModul);

		if (releasedModulStatic <= releasedModul) 
		{
			releasedModulStatic = releasedModul;
			PlayerPrefs.SetInt("Modul", releasedModulStatic);
		}
	}

	//public void chooseUjianAwalLatihan(){

	//	SceneManager.LoadScene ("Ujian AwaL Latihan");
	//}
}
