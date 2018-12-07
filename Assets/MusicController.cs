using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static MusicController instance;
    private AudioSource audioSource_sound;
    private AudioSource audioSource_music;
    public GameObject music;
    public GameObject sounds;
    public bool soundStatus=true;
    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        MakeSingleton();
        audioSource_music = music.GetComponent<AudioSource>();
     //   audioSource_sound = sounds.GetComponent<AudioSource>();
    }

    void MakeSingleton()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
    }
    public void PlayMusic(bool play)
    {
        if (play)
        {
            if (!audioSource_music.isPlaying)
                audioSource_music.Play();
        }
        else
        {
            if (audioSource_music.isPlaying)
            {
                audioSource_music.Stop();
            }
        }
    }
    public void crashPlay()
    {if(soundStatus==true)
        {
            audioSource_sound.Play();
        }
      
    }
    public void soundController(bool flag)
    {
        soundStatus = flag;
    }
    // Update is called once per frame
}
