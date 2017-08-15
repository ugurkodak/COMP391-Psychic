using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Moves))]
[RequireComponent(typeof(Powers))]
public class Player : MonoBehaviour
{
    Moves moves;
    Powers powers;
    
    Vector3 mousePosition;
    public Transform focusLight;
    const float leftEnd = -25.8f;
    const float bottomEnd = 0.5258417f;

    int focusCounter = 0;
    enum forceStates {idle, ongoing, ready, delayed, failed};
    forceStates forceState = forceStates.idle;
    string forceCombination = "";
    const string pushCombination = "qwe";
    const string teleportCombination = "qwas";

    void Awake()
    {
	focusLight = Instantiate(focusLight, new Vector3(10, 0, 0), Quaternion.identity);//Position X may cause problems at start
	moves = GetComponent<Moves>();
	powers = GetComponent<Powers>();
    }
	
    void Update()
    {
	//Boundaries
	if (transform.position.x <= leftEnd)
	    transform.position = new Vector2(leftEnd, transform.position.y);
	if (transform.position.y <= bottomEnd)
	    transform.position = new Vector2(transform.position.x, bottomEnd);
	
	//Mouse position (Player focus)
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	mousePosition.z = -1; //Remove camera z
	focusLight.position = mousePosition;

	//Move with right mouse click
	if (Input.GetKeyDown(KeyCode.Mouse1))
	{
	    if (mousePosition.x > transform.position.x)
		moves.moveRight();
	    else if (mousePosition.x < transform.position.x)
		moves.moveLeft();
	}
	if (Input.GetKeyUp(KeyCode.Mouse1))
	{
	    moves.stop();
	}

	//Use/Activate with left mouse click  
	if (Input.GetKeyDown(KeyCode.Mouse0))
	{
	    powers.setFocusPosition(new Vector2(mousePosition.x, mousePosition.y));
	    if (forceState == forceStates.ready)
	    {
		if (forceCombination == pushCombination)
		{
		    powers.forcePush();
		    forceState = forceStates.delayed;
		    Debug.Log("Delayed");
		    forceCombination = "";
		}
		else if (forceCombination == teleportCombination)
		{
		    powers.teleport();
		    forceState = forceStates.idle;
		    Debug.Log("Idle");
		    forceCombination = "";
		}
	    }
	}

	//Track force powers
	if (Input.GetKeyDown(KeyCode.Q))
	{
	    focusCounter = 0;
	    forceState = forceStates.ongoing;
	    forceCombination += "q";
	    Debug.Log("Ongoing: " + forceCombination);
	}
	else if (Input.GetKeyDown(KeyCode.W))
	{
	    focusCounter = 0;
	    forceState = forceStates.ongoing;
	    forceCombination += "w";
	    Debug.Log("Ongoing: " + forceCombination);
	}
	else if (Input.GetKeyDown(KeyCode.E))
	{
	    focusCounter = 0;
	    forceState = forceStates.ongoing;
	    forceCombination += "e";
	    Debug.Log("Ongoing: " + forceCombination);
	    if (forceCombination == pushCombination)
	    {
		forceState = forceStates.ready;
		Debug.Log("Push Ready");
	    }
	}
	else if (Input.GetKeyDown(KeyCode.A))
	{
	    focusCounter = 0;
	    forceState = forceStates.ongoing;
	    forceCombination += "a";
	    Debug.Log("Ongoing: " + forceCombination);
	}
	else if (Input.GetKeyDown(KeyCode.S))
	{
	    focusCounter = 0;
	    forceState = forceStates.ongoing;
	    forceCombination += "s";
	    Debug.Log("Ongoing: " + forceCombination);
	    if (forceCombination == teleportCombination)
	    {
		forceState = forceStates.ready;
		Debug.Log("Teleport Ready");
	    }
	}
    }

    void FixedUpdate()
    {
	//Track focus counter
        if (forceState == forceStates.ongoing)
	{
	    focusCounter++;
	    if (focusCounter >= 15)
	    {
		forceState = forceStates.failed;
		focusCounter = 0;
		forceCombination = "";
		Debug.Log("Failed");
	    }
	}
	if (forceState == forceStates.failed)
	{
	    focusCounter++;
	    if (focusCounter >= 30)
	    {
		focusCounter = 0;
		forceState = forceStates.idle;
		Debug.Log("Idle");
	    }
	}
	if (forceState == forceStates.delayed)
	{
	    focusCounter++;
	    if (focusCounter >= 30)
	    {
		focusCounter = 0;
		forceState = forceStates.idle;
		Debug.Log("Idle");
	    }
	}
    }
}
