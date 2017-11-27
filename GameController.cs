using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//[RequireComponent(typeof(AudioSource))]

public class GameController : MonoBehaviour {

	//public AudioSource audiosource;
	//public AudioClip Clip1;
	//public AudioClip Clip2;

	public Text instructionDisplayText;
	public Text scoreDisplayText;
	public Text timeRemainingDisplayText;
	public SimpleObjectPool answerButtonObjectPool;
	public Transform answerButtonParent;
	public GameObject instructionDisplay;
	//public GameObject roundEndDisplay;

	private DataController dataController;
	private RoundData currentRoundData;
	private InstructionData[] instructionPool;

	private bool isRoundActive;
	private float timeRemaining;
	private int instructionIndex;
	private int playerScore;
	private List<GameObject> answerButtonGameObjects = new List<GameObject>();

	public GameObject CorrectAnswerFeedback;
	public GameObject WrongAnswerFeedback;
	public GameObject NextLevelPanel;

	private bool isCorrect;

	// Use this for initialization
	void Start () {

		//audiosource = GetComponent<AudioSource> ();
		//audiosource.clip = Clip1;
		//audiosource.clip = Clip2;


		dataController = FindObjectOfType<DataController> ();
		currentRoundData = dataController.GetCurrentRoundData ();
		instructionPool = currentRoundData.instructions;
		timeRemaining = currentRoundData.timeLimitInSeconds;

		UpdateTimeRemainingDisplay ();

		playerScore = 0;
		instructionIndex = 0;

		ShowInstruction (); 
		isRoundActive = true;

		StartCoroutine (TextAppear ());

	}

	private void ShowInstruction()
	{
		
		RemoteAnswerButtons ();
		InstructionData instructionData = instructionPool [instructionIndex];
		instructionDisplayText.text = instructionData.instructionText;

		for (int i = 0; i < instructionData.answers.Length; i++) 
		{
			GameObject answerButtonGameObject = answerButtonObjectPool.GetObject ();
			answerButtonGameObjects.Add (answerButtonGameObject);
			answerButtonGameObject.transform.SetParent (answerButtonParent);


			AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton> ();
			answerButton.Setup(instructionData.answers[i]);
		}

	}

	private void RemoteAnswerButtons()
	{
		while (answerButtonGameObjects.Count > 0) 
		{
			answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]);
			answerButtonGameObjects.RemoveAt (0);
		}
	}

	public void AnswerButtonClicked(bool isCorrect)
	{
		if (isCorrect) 
		{
			playerScore += currentRoundData.pointsAddedForCorrectAnswer;
			scoreDisplayText.text = "Score :" + playerScore.ToString ();

			StartCoroutine (TextAppear ());
			CorrectAnswerFeedback.gameObject.SetActive (true);
			//audiosource.PlayOneShot (Clip1);
		} 
		else 
		{
			StartCoroutine (TextAppear ());
			WrongAnswerFeedback.gameObject.SetActive (true);
			//audiosource.PlayOneShot (Clip2);
		}

		if (instructionPool.Length > instructionIndex + 1) 
		{
			instructionIndex++;
			ShowInstruction ();
		} 
		else 
		{
			EndRound ();
		}
	}



	public void EndRound()
	{
		isRoundActive = false;
		instructionDisplay.SetActive (false);
		//roundEndDisplay.SetActive (true);
	}

	public void NextGame()
	{
		SceneManager.LoadScene ("Persistent(TrainingGame) 2");
	}



	public void RepeatGame()
	{
		PlayerPrefs.DeleteAll ();
		SceneManager.LoadScene ("Training Game 1");

	}
		
	private void UpdateTimeRemainingDisplay()
	{
		timeRemainingDisplayText.text = "Time : " + Mathf.Round (timeRemaining).ToString ();
	}
	// Update is called once per frame
	void Update () {

		if (isRoundActive) 
		{
			timeRemaining -=Time.deltaTime;
			UpdateTimeRemainingDisplay ();

			if (timeRemaining <= 0f) 
			{
				EndRound ();
			}
		}

		if (isRoundActive == false)
		{
			if (playerScore <= 10) 
			{
				RepeatGame ();
			} 
			else 
			{
				NextLevelPanel.gameObject.SetActive (true);
			}
		}

			
	}

	IEnumerator TextAppear()
	{
		if (CorrectAnswerFeedback == true) 
		{
			yield return new WaitForSeconds (4);
			CorrectAnswerFeedback.gameObject.SetActive (false);
		} 


		if(WrongAnswerFeedback == true)
		{
			yield return new WaitForSeconds (4);
			WrongAnswerFeedback.gameObject.SetActive (false);
		}
	}
		
}
