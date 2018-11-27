using UnityEngine;
using UnityEngine.UI;

public class SkinGroup : MonoBehaviour {

    public int skinInt;
    public PlayerSkinChanger psc;
    public WallSkinSetter wss;
    public string type;

    private void OnEnable() {
        if (PlayerPrefs.GetInt("CurrentSkin" + type) == skinInt)
            ToggleEnable();
        else ToggleDisable();

    }

    private void ToggleEnable() {
        GetComponent<Toggle>().isOn = true;
    }

    private void ToggleDisable() {
        GetComponent<Toggle>().isOn = false;
    }

    public void ClickedOn() {
        PlayerPrefs.SetInt("CurrentSkin" + type, skinInt);
        if (psc != null) psc.Refresh();
        else if (wss != null) wss.Refresh();
    }
}
