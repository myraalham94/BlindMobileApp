using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour {

	public int modul; //level modul
	public Image Lock; //"lock" is nama file png untul locked icon
	public Image Unlock;
	private string modulString;


	// Use this for initialization
	void Start () 
	{

		if (FinishModul.releasedModulStatic >= modul) 
		{
			ModulUnlocked ();
		} 
		else 
		{
			ModulLocked ();
		}
	}
		
	public void ModulSelect(string _modul)
	{
		
		modulString = _modul;
		SceneManager.LoadScene (modulString);

	}

	void ModulLocked()
	{

		GetComponent<Button> ().interactable = false;
		Lock.enabled = true;
		Unlock.enabled = false;

	}

	void ModulUnlocked(){

		GetComponent<Button> ().interactable = true;
		Lock.enabled = false;
		Unlock.enabled = true;

	}
		
}
