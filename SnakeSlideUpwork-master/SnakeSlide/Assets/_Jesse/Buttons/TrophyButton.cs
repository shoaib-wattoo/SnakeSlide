using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophyButton : MonoBehaviour, IButtonAction
{
    public void Execute()
    {
        Debug.Log("Trophy button pressed");
    }
}
