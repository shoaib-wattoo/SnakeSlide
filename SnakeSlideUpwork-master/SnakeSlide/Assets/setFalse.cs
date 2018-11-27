using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setFalse : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(GameObject.FindGameObjectWithTag("Player").transform.position.y>40f)
        {
            this.gameObject.SetActive(false);
        }
		
	}
}
