using UnityEngine;
using UnityEngine.UI;

public class GirlSkinChanger : MonoBehaviour {

    public string type;

    private void Start() {
        Refresh();
    }

    public Sprite defaultM
        , _1
        , _2
        , _3
        , _4
        , _5
        , _6
        , _7
        , _8
        , _9
        , _10
        , _11;

    public void Refresh() {
        switch (PlayerPrefs.GetInt("CurrentSkin" + type)) {
            case 0: //default
                GetComponent<Image>().sprite = defaultM;
                break;
            case 1:
                GetComponent<Image>().sprite = _1;
                break;
            case 2:
                GetComponent<Image>().sprite = _2;
                break;
            case 3:
                GetComponent<Image>().sprite = _3;
                break;
            case 4:
                GetComponent<Image>().sprite = _4;
                break;
            case 5:
                GetComponent<Image>().sprite = _5;
                break;
            case 6:
                GetComponent<Image>().sprite = _6;
                break;
            case 7:
                GetComponent<Image>().sprite = _7;
                break;
            case 8:
                GetComponent<Image>().sprite = _8;
                break;
            case 9:
                GetComponent<Image>().sprite = _9;
                break;
            case 10:
                GetComponent<Image>().sprite = _10;
                break;
            case 11:
                GetComponent<Image>().sprite = _11;
                break;
        }
    }
}
