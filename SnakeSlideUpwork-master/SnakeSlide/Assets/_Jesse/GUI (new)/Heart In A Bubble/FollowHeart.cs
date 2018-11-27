using UnityEngine;

public class FollowHeart : MonoBehaviour {

    public Transform objToFollow;
    public float speed;
    public float floatValue;
    public float followSpeed;
    private Vector3 offset;

	void Start () {
        offset = objToFollow.position - transform.position;
	}
	
	void FixedUpdate () {
        //offset.x += Mathf.Sin(Time.time * speed) * floatValue * 1.5f;
        //offset.y += Mathf.Sin(Time.time * speed / 2) * floatValue;
        //transform.position = new Vector3(transform.position.x, objToFollow.position.y, transform.position.z);
        //transform.position = Vector3.Lerp(transform.position, objToFollow.position - offset, followSpeed);
        transform.rotation = Quaternion.identity;
	}
}
