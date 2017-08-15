using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class Moves : MonoBehaviour
{
    Animator animator;
    SpriteRenderer spriteRenderer;
    
    public float speed = 0.1f;
    bool movingRight;
    bool movingLeft;
    
    
    void Awake()
    {
	animator = GetComponent<Animator>();
	spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
    void FixedUpdate()
    {
	if (movingRight)
	    transform.Translate(Vector2.right * speed);
	else if (movingLeft)
	    transform.Translate(Vector2.right * -speed);
    }
    
    public void moveRight()
    {
	movingLeft = false;
	movingRight = true;
	animator.SetBool("moving", true);
	spriteRenderer.flipX = false;
    }
    
    public void moveLeft()
    {
	movingRight = false;
	movingLeft = true;
	animator.SetBool("moving", true);
	spriteRenderer.flipX = true;
    }
    
    public void stop()
    {
	movingRight = false;
	movingLeft = false;
	animator.SetBool("moving", false);
    }
}
