using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController2 : MonoBehaviour {

	public RoundData2[] allRoundData;


	// Use this for initialization
	void Start () {

		DontDestroyOnLoad (gameObject);

		SceneManager.LoadScene ("Training Game 2");
	}

	// Update is called once per frame
	void Update () {

	}

	public RoundData2 GetCurrentRoundData(){
		return allRoundData [0];
	}
}
