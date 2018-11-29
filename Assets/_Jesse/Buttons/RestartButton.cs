using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour, IButtonAction
{
    GM gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GM>();
    }
    public void Execute()
    {
      //  ExecuteEvents.Execute(plusBtn.gameObject, newBaseEventData(__yourEventSystem__), ExecuteEvents.submitHandler);
      
        gameManager.Restart();
    }
    public void home()
    {
        SceneManager.LoadScene("gameplay");
        mode.selectedMod = 0;
    }
}
