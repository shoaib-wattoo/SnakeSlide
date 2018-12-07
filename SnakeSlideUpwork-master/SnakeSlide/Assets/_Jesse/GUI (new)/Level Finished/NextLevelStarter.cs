using System.Collections;
using UnityEngine;

public class NextLevelStarter : MonoBehaviour {

    GM gameManager;

    void Start() {
        StartCoroutine(WaitTwoSec());
        gameManager = FindObjectOfType<GM>();
    }

    IEnumerator WaitTwoSec() {
        yield return new WaitForSeconds(3.5f);
        PlayerPrefs.SetInt("StartIntroduction", 1);
        gameManager.Restart();
    }

    void Update() {

    }
}
