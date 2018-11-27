﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour, IButtonAction
{
    Text textDisplayed;
    public Sprite sound, noSound;
    public Image button;
    string[] messages = new string[2] {"Sound ON", "Sound OFF"};

    void Start()
    {
        //textDisplayed = GetComponentInChildren<Text>();
        StartCoroutine(LateStart());
    }

    IEnumerator LateStart() {
        yield return new WaitForSeconds(0.1f);
        UpdateButtonDisplay();
    }

    public void Execute()
    {
        SoundManager._instance.ToggleAudio();
        UpdateButtonDisplay();
    }

    void UpdateButtonDisplay()
    {
        if (SoundManager._instance.audioPreferences)
        {
            //textDisplayed.text = messages[0];
            button.sprite = sound;
        }
        else
        {
            button.sprite = noSound;
        }
    }
}
