using UnityEngine;
using UnityEngine.Events;

public class StartMenuDecider : MonoBehaviour {

    public GameObject startMenu;
    public UnityEvent introductionChosen;

    void Start() {
        if (PlayerPrefs.GetInt("StartIntroduction", 0) == 0)
            startMenu.SetActive(true);
        else {
            introductionChosen.Invoke();
            PlayerPrefs.SetInt("StartIntroduction", 0);
        }        
    }
}
