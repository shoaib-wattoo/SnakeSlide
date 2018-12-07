using UnityEngine;

public class Point : MonoBehaviour {

    public LevelMachine lm;
    public int id;
    public Sprite sprite;

    public void Start() {
        if (FindObjectOfType<LevelMachine>() != null) {
            lm = FindObjectOfType<LevelMachine>().GetComponent<LevelMachine>();
            id = lm.GetRightID();
            GetComponent<SpriteRenderer>().sprite = lm.GetRandomItemToSpawn(id);
        }
    }

    public Sprite GetSprite() {
        return GetComponent<SpriteRenderer>().sprite;
    }

}
