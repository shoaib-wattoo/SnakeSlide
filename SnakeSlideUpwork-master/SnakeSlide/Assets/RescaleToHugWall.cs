using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescaleToHugWall : MonoBehaviour {

    public enum SIDE_TO_HUG
    {
        LEFT,
        RIGHT
    }

    public SIDE_TO_HUG SideToHug;

    void Awake()
    {
        float leftX = Camera.main.ViewportToWorldPoint(Vector3.zero).x;
        float rightX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

        if (SideToHug == SIDE_TO_HUG.LEFT)
        {
            transform.position = new Vector3(leftX, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(rightX, transform.position.y, transform.position.z);
        }
    }
}
