using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setfalsenew : MonoBehaviour {

	public static setfalsenew instance;

	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetInt("firsttime") != 0)
		{
			this.gameObject.SetActive(false);
		}
		
	}

	public void HideTutorial(){
		Debug.Log ("Hide Tut");
		if (PlayerPrefs.GetInt ("firsttime") == 0) {
			PlayerPrefs.SetInt ("firsttime", 1);
			this.gameObject.SetActive (false);
		}
	}
}
