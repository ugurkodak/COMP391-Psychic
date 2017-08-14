using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moves : MonoBehaviour
{
    public float speed = 0.1f;
    bool movingRight;
    bool movingLeft;
	
    void FixedUpdate()
    {
	if (movingRight)
	{
	    transform.Translate(Vector2.right * speed);
	}
	else if (movingLeft)
	{
	    transform.Translate(Vector2.right * -speed);
	}
    }
    
    public void moveRight()
    {
	movingLeft = false;
	movingRight = true;
    }

    public void moveLeft()
    {
	movingRight = false;
	movingLeft = true;
    }

    public void stop()
    {
	movingRight = false;
	movingLeft = false;
    }
}
