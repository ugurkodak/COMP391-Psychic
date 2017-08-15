using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Powers : MonoBehaviour
{
    Rigidbody2D rBody;
    Moves moves;
    Vector2 focusPoint;
    Animator animator;
    int animationCounter = 0;
        
    void Awake()
    {
	animator = GetComponent<Animator>();
	rBody = GetComponent<Rigidbody2D>();
        moves = GetComponent<Moves>();
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
	
	RaycastHit2D[] hits;
	//print("Focus Point: " + focusPoint);
	//print("Player " + transform.position);
	hits = Physics2D.LinecastAll(transform.position, focusPoint);
	Debug.DrawLine(transform.position, focusPoint, Color.green, 2, false);
	for (int i = 0; i < hits.Length; i++)
	{
	    if (hits[i].transform.CompareTag("Box") || hits[i].transform.CompareTag("Enemy"))
	    {
		Vector2 pushVector = new Vector2(0, 0);
		pushVector = (focusPoint - (Vector2)transform.position).normalized;
		hits[i].collider.GetComponent<Rigidbody2D>().AddForce(pushVector *
								      10000 / (hits[i].transform.position - transform.position).magnitude);
		print(hits[i].collider.name);
		print(pushVector);
	    }
	}
    }

    public void teleport()
    {
	moves.fallingTooFast = false;
	rBody.velocity *= 0.1f;
	transform.position = focusPoint;
	Debug.Log("Teleport");
	animator.SetBool("teleporting", true);
	animationCounter++;
    }
}
