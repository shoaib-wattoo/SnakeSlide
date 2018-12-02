using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class totalGems : MonoBehaviour {
    public Text gembutton;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void gems()
    {
       gembutton.GetComponent<Text>().text= PlayerPrefs.GetInt("Gems").ToString();
    }
}
