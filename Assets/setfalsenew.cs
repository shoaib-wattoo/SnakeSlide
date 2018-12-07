using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setfalsenew : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetInt("firsttime") == 0)
        { StartCoroutine(delay()); }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator delay()
    {
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);
        PlayerPrefs.SetInt("firsttime", 1);

    }
}
