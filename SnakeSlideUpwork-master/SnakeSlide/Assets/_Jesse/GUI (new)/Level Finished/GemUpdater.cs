using UnityEngine;
using UnityEngine.UI;

public class GemUpdater : MonoBehaviour {

	void Start () {
        GetComponent<Text>().text = PlayerPrefs.GetInt("Gems", 0).ToString();
	}
	
}
