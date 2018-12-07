using UnityEngine;
using UnityEngine.UI;

public class LeftLevel : MonoBehaviour {

    void Start() {
        GetComponent<Text>().text = (PlayerPrefs.GetInt("CurrentLevel", 0) + 1).ToString();
    }
}
