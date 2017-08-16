using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool moveToPlayer = false;
    public bool pushPlayer = false;
    Transform player;
    Moves moves;
    Powers powers;

    void Awake()
    {
	moves = GetComponent<Moves>();
        powers = GetComponent<Powers>();
    }
    
    void Start()
    {
	player = GameObject.Find("Player").transform;
    }
	
    void FixedUpdate()
    {
	if (!moves.dead)
	{
	    powers.focusPoint = new Vector2(player.GetComponent<BoxCollider2D>().bounds.center.x,
					    player.GetComponent<BoxCollider2D>().bounds.center.y);
	    if (moveToPlayer)
	    {
		if (player.position.x < transform.position.x)
		    moves.moveLeft();
		if (player.position.x > transform.position.x)
		    moves.moveRight();
	    }
	    if (pushPlayer && Mathf.Abs(transform.position.x - player.position.x) < 30.0f)
	    {
		pushPlayer = false;
		StartCoroutine(push());
	    }	    
	}
    }

    IEnumerator push()
    {
	yield return new WaitForSeconds(2.0f);
	powers.forcePush();
	pushPlayer = true;
    }
}
