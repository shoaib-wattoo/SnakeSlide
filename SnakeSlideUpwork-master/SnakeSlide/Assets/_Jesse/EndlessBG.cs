using UnityEngine;
using UnityEngine.UI;

public class EndlessBG : MonoBehaviour {

    public Player player;
    public float speedScale;
    private RawImage ren;

    private void Start() {
        ren = GetComponent<RawImage>();
        //ren.SetNativeSize();
        ren.material.mainTextureOffset = Vector2.zero;
        ScaleImage();
    }

    private void ScaleImage() {
        if (ren.uvRect.height > ren.uvRect.width)
            ren.uvRect = new Rect(ren.uvRect.x, ren.uvRect.y, 500, 500);
        else if (ren.uvRect.width > ren.uvRect.height)
            ren.uvRect = new Rect(ren.uvRect.x, ren.uvRect.y, ren.uvRect.width, ren.uvRect.width);
    }

    void FixedUpdate() {
        if (player != null)
            ren.material.mainTextureOffset += new Vector2(0, speedScale * player.GetCurrentSpeed());
    }
}
