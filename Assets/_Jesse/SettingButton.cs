using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingButton : MonoBehaviour {
    public Sprite[] OffSprite;
    public Sprite[] OnSprite;
    public Button but;
    public Button but2;
    public int select;
    GM gameManager;
    public void ChangeImage()
    {
      
            PlayerPrefs.SetInt("arcade", 0);
            PlayerPrefs.SetInt("story", 1);
            but.image.sprite = OffSprite[0];
            but2.image.sprite = OnSprite[1];
            mode.selectedMod = 1;
        Start();
        GM.newRestart = false;
        SceneManager.LoadScene("gameplay");
        //    MusicController.instance.PlayMusic(false);




    }
    public void ChangeButtonArcade()
    {
        {
            mode.selectedMod = 2;
            PlayerPrefs.SetInt("arcade", 1);
            PlayerPrefs.SetInt("story", 0);
            but.image.sprite = OnSprite[0];
            but2.image.sprite = OffSprite[1];
            Start();
            SceneManager.LoadScene("gameplay");

            // MusicController.instance.PlayMusic(true);
        }
    }

 
    void Start()
    {
        
            if (mode.selectedMod==1)
            {
                but.image.sprite = OffSprite[0];
            but2.image.sprite = OnSprite[1];
        }
            else  if (mode.selectedMod == 2)
            {
            but.image.sprite = OnSprite[0];
            but2.image.sprite = OffSprite[1];
        }
            else
        {
            but.image.sprite = OnSprite[0];
            but2.image.sprite = OffSprite[1];
        }
        
      
       

        
    }
}
