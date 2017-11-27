using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton2 : MonoBehaviour {

	public Text answerText;

	private AnswerData2 answerData;

	private GameController2 gameController;

	// Use this for initialization
	void Start () {

		gameController = FindObjectOfType<GameController2> ();
	}

	public void Setup(AnswerData2 data){

		answerData = data;
		answerText.text = answerData.answerText;

	}

	public void HandleClick(){

		gameController.AnswerButtonClicked (answerData.isCorrect);
	}
}
