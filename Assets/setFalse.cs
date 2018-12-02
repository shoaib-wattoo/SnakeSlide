using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setFalse : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        if(PlayerPrefs.GetInt("firsttime")>0)
        {
            gameObject.SetActive(false);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("firsttime") == 0)
        {
            try
            {
                if (GameObject.FindGameObjectWithTag("Player").transform.position.y > 40f)
                {
                    this.gameObject.SetActive(false);
                }

            }
            catch (NullReferenceException)
            {

            }
        }
    }
}
