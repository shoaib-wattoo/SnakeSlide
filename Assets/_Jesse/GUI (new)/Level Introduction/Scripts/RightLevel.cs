using UnityEngine;
using UnityEngine.UI;

public class RightLevel : MonoBehaviour {

    void Start() {
        GetComponent<Text>().text = (PlayerPrefs.GetInt("CurrentLevel", 0) + 2).ToString();
    }
}
