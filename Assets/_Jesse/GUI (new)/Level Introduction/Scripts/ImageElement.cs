using UnityEngine;
using UnityEngine.UI;

public class ImageElement : MonoBehaviour {

    public Image image;
    public Text num;

    public void SetValues(Sprite img, int n) {
        image.sprite = img;
        num.text = n.ToString();
    }
}
