using UnityEngine;
using UnityEngine.UI;

public class WallSkinSetter : MonoBehaviour {

    public Spawner spawner;
    public RawImage bg;

    public WallSkinHolder defaultSkin;

    public WallSkinHolder[] wallSkins;

    void Start () {
        Refresh();
    }

    public void Refresh() {
        int i = (PlayerPrefs.GetInt("CurrentSkin" + "theme", 0));
        Material mat = Instantiate(bg.material);
        mat.mainTexture = wallSkins[i].bg;
        bg.material = mat;
        spawner.SetSkins(wallSkins[i]);
    }
}
