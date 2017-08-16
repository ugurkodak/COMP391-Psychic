using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAndBackground : MonoBehaviour
{
    public Transform theCamera;
    public Transform background;
    
    void Update()
    {
	if (transform.position.x >= 0 && transform.position.x <= 160)
	{
	    if (transform.position.x - theCamera.position.x > 0)
	    {
	    	background.position = new Vector3(background.position.x + transform.position.x - theCamera.position.x - 0.01f,
	    					   background.position.y, background.position.z);
	    }
	    else if (transform.position.x - theCamera.position.x < 0)
	    {
	    	background.position = new Vector3(background.position.x + transform.position.x - theCamera.position.x + 0.01f,
	    					   background.position.y, background.position.z);
	    }
	    theCamera.position = new Vector3(transform.position.x, theCamera.position.y, theCamera.position.z);
	}
    }
}
