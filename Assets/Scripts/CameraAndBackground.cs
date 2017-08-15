using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAndBackground : MonoBehaviour
{
    public Transform theCamera;
    public Transform background;
    
    Transform background1;
    Transform background2;

    void Start()
    {
	background1 = background.Find("Background1");
	background2 = background.Find("Background2");
    }
    
    void Update()
    {
	if (transform.position.x >= 0)
	{
	    if (Mathf.Abs(transform.position.x - theCamera.position.x) > 0)
	    {
	    	background1.position = new Vector3(background1.position.x + transform.position.x - theCamera.position.x - 0.01f,
	    					   background1.position.y, background1.position.z);
	    }
	    theCamera.position = new Vector3(transform.position.x, theCamera.position.y, theCamera.position.z);
	}
    }
}
