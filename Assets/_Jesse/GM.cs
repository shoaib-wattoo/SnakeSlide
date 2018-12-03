﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


public class GM : MonoBehaviour
{
    public GameObject []arcadeMode;
    public GameObject[] Storymode;
    #region STATES
    public GameObject adbanner_Prefab;
    static bool isbannerAdded = false;
    AdBanner adBanner;

    public enum GAMESTATE
    {
        LOAD,
        GAMEOVER,
        RESTART,
        PLAY,
        LOSE
    }

    GAMESTATE _gamestate;

    public GAMESTATE Gamestate
    {
        get { return _gamestate; }
        set
        {
            _gamestate = value;
            Debug.Log(string.Format("Gamestate: {0}", value));
            switch (value)
            {
                case GAMESTATE.LOAD:
                    Load();
                    Gamestate = GAMESTATE.PLAY;
                    break;

                case GAMESTATE.LOSE:
                    adBanner.CreateInterstitial();
                    adBanner.ShowInterstital();
                    deathEvent.Invoke();
                    SoundManager._instance.PlayMusic(false);
                    SoundManager._instance.PlayDieSound();
                    Gamestate = GAMESTATE.GAMEOVER;
                    //  adBanner.CreateInterstitial();
                    break;

                case GAMESTATE.GAMEOVER:
                    DisplayGameOver();
                    break;

                case GAMESTATE.RESTART:
                    {
                        PlayerPrefs.SetInt("restart", 0);
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                
                       
                        break;
                    }

                case GAMESTATE.PLAY:
                    DisplayRestart();
                    SoundManager._instance.PlayMusic(true);
                    break;

            }

        }
    }

    #endregion

    public static GM _instance;

    public GameObject InGameCanvas;
    public GameObject GameOverCanvas;

    public Text scoreText;
    public Text scoreEndText;
    public Text highScoreText;
    public Text gemsEndText;

    public UnityEvent deathEvent;

    int highScore = 0;
    int points = 0;
    int gems = 0;


    //-------
    void Awake()
    {
      
       


        if (_instance == null)
        {
            _instance = this;
        } else if (_instance != this)
        {
            Destroy(this);
        }   
    }

    void Start()
    {

        StartCoroutine(delayStart());
        Gamestate = GAMESTATE.LOAD;
        Debug.Log("Start");
        if (!isbannerAdded)
            Instantiate(adbanner_Prefab);
        isbannerAdded = true;
        adBanner = GameObject.Find("Scriptmanager(Clone)").GetComponent<AdBanner>();
    }


    #region scoreHandling
    public void PointsUp()
    {
        SoundManager._instance.PlayPointSound();
        if (++points > highScore)
        {
            highScore = points;
            Save();
        }

        scoreText.text = points.ToString();
    }

    public void GemsUp()
    {
        SoundManager._instance.PlayGemSound();
        //gems++;
        //gemsUiText.text = gems.ToString();
        //Save();
    }

    public void GemsUp(int amt) // For microtransactions
    {
        //gems += amt;
        //Save();
    }
    #endregion
    
    
    public void StartGame() {
        //gemsUiText.text = gems.ToString();
    }

    public void DisplayGameOver()
    {
        InGameCanvas.SetActive(false);
        //GameOverCanvas.SetActive(true);
        scoreEndText.text = "Score: " + points.ToString();
        highScoreText.text = "Highscore: " + highScore.ToString();
        //gemsEndText.text = "GEMS: " + gems.ToString();
        //gemsDeathUiText.text = gems.ToString();
    }

    public void DisplayRestart()
    {
        GameOverCanvas.SetActive(false);
        InGameCanvas.SetActive(true);
    }

    public void Restart()
    {
        Gamestate = GAMESTATE.RESTART;
        
    }

    #region SAVE/LOAD
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData(highScore, gems, SoundManager._instance.audioPreferences);

        //PlayerPrefs.SetInt("Gems", gems);
        
        // take our playerdata and save it to "file"
        bf.Serialize(file, data);   
        file.Close();
    }

    public void GetAudioPreferances() {
        
    }

    public void Load()
    {
        // get highscore, sound preference, gems
        if (!File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            Save();
        }

        //Debug.Log(Application.persistentDataPath + "/playerInfo.dat");
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat",FileMode.Open);
        PlayerData data = (PlayerData)bf.Deserialize(file);
        file.Close();

        // Setup data
        highScore = data.highscore;
        //gems = data.gems;
        SoundManager._instance.audioPreferences = data.audioPreferences;
    }
    public static bool newRestart;
    IEnumerator delayStart()
    {
       // PlayerPrefs.SetInt("mode", 0);
        yield return new WaitForSeconds(0.01f);
      //  if (PlayerPrefs.GetInt("mode") == 2) 
     
       // else if (PlayerPrefs.GetInt("mode") == 1)
        if(mode.selectedMod==1)
        {
            Storymode[0].SetActive(true);
            Storymode[1].SetActive(true);
            Storymode[2].SetActive(false);
            Storymode[3].SetActive(false);
           if(newRestart)
            {
                Storymode[1].SetActive(false);
                Storymode[4].SetActive(true);
                arcadeMode[1].SetActive(true);
                Player._instance.StartGame();

            }
        }
        else
        {
            if (PlayerPrefs.GetInt("firsttime") == 1)
            {

                arcadeMode[0].SetActive(true);
                arcadeMode[1].SetActive(true);
                arcadeMode[2].SetActive(false);
                arcadeMode[3].GetComponent<Animator>().SetTrigger("Appear");
                Player._instance.StartGame();
            }
           




        }



        yield return new WaitForSeconds(2f);
        

    }
    #endregion
}

[Serializable]  // serializable: can now save this to a file (no monobehavior's allowed!)
class PlayerData
{
    public int highscore;
    public int gems;
    public bool audioPreferences;

    public PlayerData(int highscore, int gems, bool audioPreference)
    {
        this.highscore = highscore;
        this.gems = gems;
        this.audioPreferences = audioPreference;
    }
   
}
