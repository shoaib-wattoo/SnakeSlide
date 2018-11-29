using UnityEngine;

public class WallSkinHolder : MonoBehaviour {

    public Sprite triangleCenter, triangleLeft, triangleRight;
    public Texture bg;

    public Sprite GetAppropriateSprite(string str) {
        if (triangleCenter.name == str)
            return triangleCenter;
        else if (triangleLeft.name == str)
            return triangleLeft;
        else if (triangleRight.name == str)
            return triangleRight;
        return null;
    }

}
