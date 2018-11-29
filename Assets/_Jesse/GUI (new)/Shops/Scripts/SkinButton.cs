using UnityEngine;
using UnityEngine.UI;

public class SkinButton : MonoBehaviour {

    public GameObject toggle;
    public GemCounter gc;

    public string skinKey;
    public int price;
    public Text priceText;
    public string type;

    private void Start() {
        priceText.text = price.ToString();
        switch (PlayerPrefs.GetInt(skinKey + type)) {
            case 0: // not purchased
                //keep as button
                break;
            case 1: // purchased
                ChangeToToggle();
                break;
        }
    }

    public void Pressed() {
        if (PlayerPrefs.GetInt("Gems") >= price)
            Purchase();
    }

    private void ChangeToToggle() {
        toggle.SetActive(true);
        gameObject.SetActive(false);
    }

    private void Purchase() {
        ChangeToToggle();
        //PlayerPrefs.SetInt("StarCount", PlayerPrefs.GetInt("StarCount") - price);
        PlayerPrefs.SetInt(skinKey + type, 1);
        gc.Refresh(price);
    }
}
