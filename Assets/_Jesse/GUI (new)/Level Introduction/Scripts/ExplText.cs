using UnityEngine;
using UnityEngine.UI;

public class ExplText : MonoBehaviour {

    public LevelMachine lm;

	void Start () {
        GetComponent<Text>().text = lm.GetExplText();
    }
}
