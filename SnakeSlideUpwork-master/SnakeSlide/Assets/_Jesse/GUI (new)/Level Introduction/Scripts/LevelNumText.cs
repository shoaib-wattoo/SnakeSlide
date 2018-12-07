using UnityEngine;
using UnityEngine.UI;

public class LevelNumText : MonoBehaviour {
    
	void Start () {
        GetComponent<Text>().text = "Level " + (PlayerPrefs.GetInt("CurrentLevel", 0) + 1).ToString();
	}
}
