using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player _instance;
    public GameObject hold_left;
    const int MAX_BODY_PARTS = 15;
    const float maxAngleR = -45f;
    const float maxAngleL = 45f;
    int x;
    public bool debugMode;
    
    
    public List<Transform> BodyParts = new List<Transform>();
    public int beginSize;
    public float acceleration;
    public float deacceleration;
    public float speedScaleForDrift;
    private float xVelocity;
    private float previousX;
    public Transform rightAngleObject;
    public Transform leftAngleObject;
    public float maxSpeed = 6f; //speed player reaches after a couple seconds at start
    public float curSpd = 0f;   // this speed is what actually controls the player, it slowly increases * acceleration
    public float rotSpd = 3f;   //feels close to real game

    private float leftOverSpeedLeft, leftOverSpeedRight;
    private Vector3 rotationUpLeft, rotationUpRight;

    private bool gameStarted; //if true game starts

    public GameObject bodyPrefab;
    
    
    void Start () {
        Application.targetFrameRate = 60;
        rotationUpLeft = leftAngleObject.up;
        rotationUpRight = rightAngleObject.up;
        if (_instance == null)
        {
            _instance = this;
        } else if (_instance != this)
        {
            Destroy(this);
        }


        for (var i = 0; i < beginSize - 1; i++)
        {
            //AddBodyPart(sprite);
        }
    //   PlayerPrefs.SetInt("firsttime", 0);

        //StartCoroutine("RevEngine");
        //StartCoroutine("FillBuffer");


        if (TransformationBuffer._instance == null)
            Debug.Log("buffer missing");
    }
    
    void FixedUpdate () {

        if (gameStarted)

        {
            
            //(holdhold());
            
            Move();
        }


        //if (Input.GetMouseButtonDown(1))
            //AddBodyPart();
    }

    public void Move()
    {
        Accelerate();

        xVelocity = ((BodyParts[0].position.x - previousX)) / Time.deltaTime;
        previousX = BodyParts[0].position.x;
      //  Debug.Log(xVelocity);

        float goal = maxAngleR;
        // snake head always moves right (45), unless input (-45)
        if (Input.GetMouseButton(0)) {
            //rotationUpLeft = BodyParts[0].transform.up;
            goal = maxAngleL;
            leftOverSpeedLeft = -xVelocity * speedScaleForDrift;
            BodyParts[0].position += rotationUpRight * leftOverSpeedRight * Time.deltaTime;
        } else {
          //  Debug.Log("NotPressed");
            //rotationUpRight = BodyParts[0].transform.up;
            leftOverSpeedRight = xVelocity * speedScaleForDrift;
            BodyParts[0].position += rotationUpLeft * leftOverSpeedLeft * Time.deltaTime;
        }
        
        if (debugMode)
            goal = 0;


        Quaternion newR = Quaternion.AngleAxis(goal, Vector3.forward);
        BodyParts[0].rotation = Quaternion.Slerp(BodyParts[0].transform.rotation, 
                                                    newR, 
                                                    rotSpd * Time.deltaTime);


        BodyParts[0].position += BodyParts[0].up * curSpd * Time.deltaTime;
        if (leftOverSpeedRight > 0) {
            leftOverSpeedRight -= deacceleration;
        }
        if (leftOverSpeedRight < 0) {
            leftOverSpeedRight = 0;
        }
        if (leftOverSpeedLeft > 0) {
            leftOverSpeedLeft -= deacceleration;
        }
        if (leftOverSpeedLeft < 0) {
            leftOverSpeedLeft = 0;
        }
    }

    private void Accelerate() {
        if (curSpd < maxSpeed)
            curSpd += acceleration;
    }

    public void AddBodyPart(Sprite sprite)
    {
        if (BodyParts.Count > MAX_BODY_PARTS)           // don't add parts beyond what player can see!
        {
            return;
        }
        
        Transform newPart = (Instantiate(bodyPrefab, BodyParts[BodyParts.Count-1].position, 
                                            BodyParts[BodyParts.Count - 1].rotation) 
                                            as GameObject).transform;

        var partClass = newPart.GetComponent<TestFollow>();
        newPart.gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        
        Transformation tranformation = new Transformation(BodyParts[BodyParts.Count - 1].rotation,
                                                            BodyParts[BodyParts.Count - 1].position,
                                                            BodyParts[BodyParts.Count - 1].up);
        if (x == 0)
        {
            x++;
            partClass.Setup(BodyParts.Count - 1, tranformation, BodyParts[BodyParts.Count - 1], 1f);
        }
        else
        {
            partClass.Setup(BodyParts.Count - 1, tranformation, BodyParts[BodyParts.Count - 1], 0.4f);

        }
        newPart.SetParent(transform);
        BodyParts.Add(newPart);
     
    }

    IEnumerator RevEngine()
    {
        while (curSpd < maxSpeed)
        {
            curSpd += acceleration * Time.deltaTime;
            yield return null;
        }

        curSpd = maxSpeed;
        //Debug.Log("Player speed reached peak... ending coroutine RevEngine");
        StopCoroutine("RevEngine");
    }


    // Store a circular buffer of Transformations (pos/rot) that creat a path of waypoints
    //IEnumerator FillBuffer()
    void LateUpdate()
    {
        //while (true)
        //{
        var head = BodyParts[0];
        Transformation t = new Transformation(head.rotation, head.position, head.up);
        TransformationBuffer._instance.AddTransformation(t);

        //yield return new WaitForSeconds(1 * Time.deltaTime);
        //}
    }

    // Used by Start Menu buttons to start the game.
    public void StartGame() {
        gameStarted = true;
    }

    public float GetCurrentSpeed() {
        return curSpd;
    }
  //IEnumerator holdhold()
  //  {
  //      hold_left.SetActive(true)   ;
  //      yield return new WaitForSeconds(2f);
  //      hold_left.SetActive(false);
  //  }
}
