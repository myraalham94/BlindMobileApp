using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController2 : MonoBehaviour {

	public AudioClip CorrectAnswer;
	public AudioClip WrongAnswer;

	public Text instructionDisplayText;
	public Text scoreDisplayText;
	public Text timeRemainingDisplayText;
	public SimpleObjectPool answerButtonObjectPool;
	public Transform answerButtonParent;
	public GameObject instructionDisplay;
	//public GameObject roundEndDisplay;
	public GameObject trainingDone;

	private DataController2 dataController;
	private RoundData2 currentRoundData;
	private InstructionData2[] instructionPool;

	private bool isRoundActive;
	private float timeRemaining;
	private int instructionIndex;
	private int playerScore;
	private List<GameObject> answerButtonGameObjects = new List<GameObject>();

	public GameObject CorrectAnswerFeedback;
	public GameObject WrongAnswerFeedback;

	private bool isCorrect;

	// Use this for initialization
	void Start () {

		dataController = FindObjectOfType<DataController2> ();
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
		InstructionData2 instructionData = instructionPool [instructionIndex];
		instructionDisplayText.text = instructionData.instructionText;

		for (int i = 0; i < instructionData.answers.Length; i++) 
		{
			GameObject answerButtonGameObject = answerButtonObjectPool.GetObject ();
			answerButtonGameObjects.Add (answerButtonGameObject);
			answerButtonGameObject.transform.SetParent (answerButtonParent);


			AnswerButton2 answerButton = answerButtonGameObject.GetComponent<AnswerButton2> ();
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

		}
		else 
		{
			StartCoroutine (TextAppear ());
			WrongAnswerFeedback.gameObject.SetActive (true);

		}

		if (instructionPool.Length > instructionIndex + 1) {
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
		

	public void RepeatGame()
	{
		PlayerPrefs.DeleteAll ();
		SceneManager.LoadScene ("Training Game 2");

	}

	private void UpdateTimeRemainingDisplay()
	{
		timeRemainingDisplayText.text = "Time : " + Mathf.Round (timeRemaining).ToString ();
	}
	// Update is called once per frame
	void Update () {

		if (isRoundActive) {
			timeRemaining -= Time.deltaTime;
			UpdateTimeRemainingDisplay ();

			if (timeRemaining <= 0f) {
				EndRound ();
			}
		}

		if (isRoundActive == false) 
		{
			if (playerScore <= 30) 
			{
				RepeatGame ();
			} 
			else 
			{
				trainingDone.gameObject.SetActive (true);
			}

			//if (playerScore >= 10) 
			//{
				//trainingDone.gameObject.SetActive (true);
			//}
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

	public void TrainingDone(){
		
		SceneManager.LoadScene ("Main Menu");
	}


}
