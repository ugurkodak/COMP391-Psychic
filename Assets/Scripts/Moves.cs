using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class Moves : MonoBehaviour
{
    Animator animator;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rBody;
    
    public float speed = 0.1f;
    bool movingRight;
    bool movingLeft;
    public bool fallingTooFast;
    public bool dead = false;
    
    
    void Awake()
    {
	animator = GetComponent<Animator>();
	spriteRenderer = GetComponent<SpriteRenderer>();
        rBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
	if (rBody.velocity.y < -26.0f)
	    fallingTooFast = true;
	if (rBody.velocity.x > 20)
	{
	    dead = true;
	    animator.SetBool("dead", true);
	}
    }
    
    void FixedUpdate()
    {
	if (movingRight)
	    transform.Translate(Vector2.right * speed);
	else if (movingLeft)
	    transform.Translate(Vector2.right * -speed);
    }
  
    void OnCollisionEnter2D(Collision2D other)
    {
	if (fallingTooFast && other.transform.CompareTag("Platform"))
	{
	    animator.SetBool("dead", true);
	    print("dead");
	}
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
