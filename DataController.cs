using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(AudioSource))]

public class DataController : MonoBehaviour {

	public RoundData[] allRoundData;

	// Use this for initialization
	void Start () 
	{
		
		DontDestroyOnLoad (gameObject);

		SceneManager.LoadScene ("Training Game 1");

	}


	// Update is called once per frame
	void Update () 
	{
		
	}


	public RoundData GetCurrentRoundData()
	{
		return allRoundData [0];
	}

}
