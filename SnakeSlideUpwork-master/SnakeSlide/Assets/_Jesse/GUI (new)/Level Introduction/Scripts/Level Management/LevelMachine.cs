using UnityEngine;

public class LevelMachine : MonoBehaviour {

    // Set level settings in editor with Element 0 being level 1 settings; Element 1 being level 2 and so on.
    public LevelSettings[] levelSettings;

    private int amountOfUniqueObjects;

    private int currentLevel;
    private int[] objectIDS;
    private int[] collectedItems;
    public GameObject levelElementPrefab;
    public Transform listParent;

    private void Awake() {
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 0);
    }

    private void Start() {
        amountOfUniqueObjects = levelSettings[currentLevel].GetNumOfUniqueObjects();
        collectedItems = (int[]) levelSettings[currentLevel].amountToCollect.Clone();
        SpawnLevelElements();
    }

    public string GetExplText() {
        return levelSettings[currentLevel].levelDiscription;
    }

    private void SpawnLevelElements() {
        for (int i = 0; i < levelSettings[currentLevel].amountToCollect.Length; i++) {
            Instantiate(levelElementPrefab, listParent.transform).GetComponent<ImageElement>().SetValues(
                levelSettings[currentLevel].itemImage[i],
                levelSettings[currentLevel].amountToCollect[i]);
        }
    }

    public void CreateUniqueObjectIDS(int num) {
        objectIDS = new int[num];
        for (int i = 0; i < num; i++) {
            objectIDS[i] = i;
        }
    }

    public bool CheckIfRightSprite(int id) {
        bool temp = false;
        if (collectedItems[id] - 1 >= 0) {
            temp = true;
        }
        return temp;
    }

    public bool CheckIfRightObject(int id) {
        bool temp = false;
        if (collectedItems[id] - 1 >= 0) {
            temp = true;
            collectedItems[id] -= 1;
        }
        return temp;
    }

    public Sprite GetRandomItemToSpawn(int value) {
        return levelSettings[currentLevel].GetItemSpriteArray()[value];
    }

    public int GetRightID() {
        for (int i = 0; i < GetLengthOfArrays() + 1; i++) {
            if (collectedItems[i] - 1 >= 0) {
                return i;
            }
        }        
        return 0;
    }

    public int GetLengthOfArrays() {
        return levelSettings[currentLevel].GetItemSpriteArray().Length;
    }
        
    public int GetAmountOfUniqueObj() {
        return amountOfUniqueObjects;
    }

    public void StartLevel() {

    }

    public int GetNumToCollectTotal() {
        return levelSettings[currentLevel].GetNumToCollectTotal();
    }
}
