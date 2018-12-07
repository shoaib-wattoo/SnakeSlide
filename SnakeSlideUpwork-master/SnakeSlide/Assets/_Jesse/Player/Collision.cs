using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Handle all player collision here:
/// - bounds & walls (gameover)
/// - points & gems
/// </summary>
public class Collision : MonoBehaviour
{
    
    public ProgressBarController pbc;
    GM gm;
    Player _player;
    public GemTextCounter gtc;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GM>();
        _player = GetComponentInParent<Player>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(string.Format("Player collision: {0}", other.name));

        if (other.GetComponent<Boundary>() || other.GetComponent<Wall>())
        {
            GameObject.Destroy(transform.parent.gameObject);
            gm.Gamestate = GM.GAMESTATE.LOSE;

        } else if (other.GetComponent<Point>())
        {
            _player.AddBodyPart(other.GetComponent<Point>().GetSprite());
            if (pbc != null) pbc.ItemCollected(other.GetComponent<Point>().id);
            gm.PointsUp();
            Destroy(other.gameObject);
        } else if (other.GetComponent<Gem>())
        {
            gm.GemsUp();
            gtc.AddGem();
            other.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(destroyy(other.gameObject));
            
        }
    }

    void Update()
    {
        CheckDead();
    }

    void CheckDead()
    {
        float leftX = Camera.main.ViewportToWorldPoint(Vector3.zero).x;
        float rightX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;


        if (transform.position.x <=  leftX || transform.position.x >= rightX)
        {
            GameObject.Destroy(transform.parent.gameObject);
            gm.Gamestate = GM.GAMESTATE.LOSE;
        }
    }
 IEnumerator destroyy(GameObject other)
    {
        other.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(2f);
        Destroy(other);

    }  
}
