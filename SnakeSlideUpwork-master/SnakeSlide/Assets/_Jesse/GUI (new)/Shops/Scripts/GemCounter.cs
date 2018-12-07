using UnityEngine;
using UnityEngine.UI;

public class GemCounter : MonoBehaviour {

    private int currScore, targScore;
    private bool startAdding;
    private Text text;
    private Animator anim;

    void Start() {
        text = GetComponent<Text>();
        anim = GetComponent<Animator>();
        text.text = PlayerPrefs.GetInt("Gems").ToString();
    }

    private void Update() {
        if (startAdding) {
            if (currScore < targScore) currScore++;
            if (currScore > targScore) currScore -= 10;
            text.text = currScore.ToString();
            if (currScore == targScore) startAdding = false;
        }
    }

    public void AddCoins() {
        currScore = PlayerPrefs.GetInt("Gems");
        PlayerPrefs.SetInt("Gems", currScore + 20);
        targScore = currScore + 20;
        startAdding = true;
        anim.SetTrigger("Add");
    }

    public void Refresh(int price) {
        currScore = PlayerPrefs.GetInt("Gems");
        PlayerPrefs.SetInt("Gems", currScore - price);
        targScore = currScore - price;
        startAdding = true;
        anim.SetTrigger("Add");
    }
}
