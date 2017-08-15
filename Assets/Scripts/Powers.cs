using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Powers : MonoBehaviour
{
    Vector2 focusPoint;
    Animator animator;
    int animationCounter = 0;
        
    void Awake()
    {
	animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
	if (animationCounter > 0)
	{
	    if (animationCounter >= 10)
	    {
		animator.SetBool("teleporting", false);
		animator.SetBool("pushing", false);
		animationCounter = 0;
	    }
	    animationCounter++;
	}
    }

    public void setFocusPosition(Vector2 position)
    {
	focusPoint = position;
    }

    public void forcePush()
    {
	Debug.Log("Force Push");
	animator.SetBool("pushing", true);
	animationCounter++;
    }

    public void teleport()
    {
	transform.position = focusPoint;
	Debug.Log("Teleport");
	animator.SetBool("teleporting", true);
	animationCounter++;
    }
}
