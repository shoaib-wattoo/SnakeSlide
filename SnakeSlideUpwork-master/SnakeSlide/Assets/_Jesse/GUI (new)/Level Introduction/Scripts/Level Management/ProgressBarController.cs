using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ProgressBarController : MonoBehaviour {

    public Image fillBar;
    public LevelMachine lm;
    public UnityEvent LevelFinishedEvent;
    private int numToCollectTotal;

    private void Start() {
        numToCollectTotal = lm.GetNumToCollectTotal();
    }


    public void ItemCollected(int id) {
        if (lm.isActiveAndEnabled && lm.CheckIfRightObject(id))
            fillBar.fillAmount += (1f / numToCollectTotal);
        if (fillBar.fillAmount == 1) {
            LevelFinishedEvent.Invoke();
            PlayerPrefs.SetInt("CurrentLevel", PlayerPrefs.GetInt("CurrentLevel", 0) + 1);
        }
    }
}
