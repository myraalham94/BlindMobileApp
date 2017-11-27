using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[RequireComponent(typeof(AudioSource))]

public class InstructionData { //cannot put MonoBehaviour for saving data

	public string instructionText;
	public AnswerData[] answers;
	public AudioClip InstructionAudio;

}
