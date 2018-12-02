using UnityEngine;
using UnityEngine.UI;

public class PlayerSkinChanger : MonoBehaviour {

    public string type;

    private void Start() {
        Refresh();
    }

    private void OnEnable() {
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
        , _11
        , _12
        , _13
        , _14
        , _15;

    public void Refresh() {
        if (GetComponent<SpriteRenderer>() != null) {
            switch (PlayerPrefs.GetInt("CurrentSkin" + type)) {
                case 0: //default
                    GetComponent<SpriteRenderer>().sprite = defaultM;
                    break;
                case 1:
                    GetComponent<SpriteRenderer>().sprite = _1;
                    break;
                case 2:
                    GetComponent<SpriteRenderer>().sprite = _2;
                    break;
                case 3:
                    GetComponent<SpriteRenderer>().sprite = _3;
                    break;
                case 4:
                    GetComponent<SpriteRenderer>().sprite = _4;
                    break;
                case 5:
                    GetComponent<SpriteRenderer>().sprite = _5;
                    break;
                case 6:
                    GetComponent<SpriteRenderer>().sprite = _6;
                    break;
                case 7:
                    GetComponent<SpriteRenderer>().sprite = _7;
                    break;
                case 8:
                    GetComponent<SpriteRenderer>().sprite = _8;
                    break;
                case 9:
                    GetComponent<SpriteRenderer>().sprite = _9;
                    break;
                case 10:
                    GetComponent<SpriteRenderer>().sprite = _10;
                    break;
                case 11:
                    GetComponent<SpriteRenderer>().sprite = _11;
                    break;
                case 12:
                    GetComponent<SpriteRenderer>().sprite = _12;
                    break;
                case 13:
                    GetComponent<SpriteRenderer>().sprite = _12;
                    break;
                case 14:
                    GetComponent<SpriteRenderer>().sprite = _14;
                    break;
                case 15:
                    GetComponent<SpriteRenderer>().sprite = _15;
                    break;
            }
        } else if (GetComponent<Image>() != null) {
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
                case 12:
                    GetComponent<Image>().sprite = _12;
                    break;
                case 13:
                    GetComponent<Image>().sprite = _13;
                    break;
                case 14:
                    GetComponent<Image>().sprite = _14;
                    break;
                case 15:
                    GetComponent<Image>().sprite = _15;
                    break;

            }
        }
    }
}
