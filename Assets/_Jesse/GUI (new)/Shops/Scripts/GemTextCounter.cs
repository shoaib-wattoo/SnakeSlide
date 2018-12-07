using UnityEngine;
using UnityEngine.UI;

public class GemTextCounter : MonoBehaviour {
    
	void Start () {
        GetComponent<Text>().text = PlayerPrefs.GetInt("Gems", 0).ToString();
	}

    public void AddGem() {
        PlayerPrefs.SetInt("Gems", PlayerPrefs.GetInt("Gems", 0) + 1);
        GetComponent<Text>().text = PlayerPrefs.GetInt("Gems", 0).ToString();
    }
	
	void Update () {
		
	}
}
