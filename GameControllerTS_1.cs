using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerTS_1 : MonoBehaviour {

	public Text instructionDisplayText;
	public Text scoreDisplayText;
	public Text timeRemainingDisplayText;
	public SimpleObjectPool answerButtonObjectPool;
	public Transform answerButtonParent;
	public GameObject instructionDisplay;
	public GameObject roundEndDisplay;

	private DataController dataController;
	private RoundData currentRoundData;
	private InstructionData[] instructionPool;

	private bool isRoundActive;
	private float timeRemaining;
	private int instructionIndex;
	private int playerScore;
	private List<GameObject> answerButtonGameObjects = new List<GameObject>();

	// Use this for initialization
	void Start () {

		dataController = FindObjectOfType<DataController> ();
		currentRoundData = dataController.GetCurrentRoundData ();
		instructionPool = currentRoundData.instructions;
		//timeRemaining = currentRoundData.timeLimitInSeconds;

		UpdateTimeRemainingDisplay ();

		playerScore = 0;
		instructionIndex = 0;

		ShowInstruction (); 
		isRoundActive = true;

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
			//playerScore += currentRoundData.pointsAddedForCorrectAnswer;
			//scoreDisplayText.text = "Score :" + playerScore.ToString ();
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
		roundEndDisplay.SetActive (true);
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
			if (playerScore <= 10) {
				RepeatGame ();
			} 
			else 
			{
				NextGame ();
			}
		}


	}
}
