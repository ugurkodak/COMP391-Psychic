using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powers : MonoBehaviour
{
    Vector2 focusPoint;
        
    void Update()
    {
	
    }

    public void setFocusPosition(Vector2 position)
    {
	focusPoint = position;
    }

    public void forcePush()
    {
	Debug.Log("Force Push");
    }

    public void teleport()
    {
	Debug.Log("Teleport");	
    }
}
