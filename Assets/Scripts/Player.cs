using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Moves))]
[RequireComponent(typeof(Powers))]
public class Player : MonoBehaviour
{
    public Transform focusStateIndicator;
    SpriteRenderer indicator;
    Moves moves;
    Powers powers;
    
    Vector3 mousePosition;
    public Transform focusLight;
    const float leftEnd = -25.8f;
    const float bottomEnd = 0.5258417f;
    const float rightEnd = 185.6f;

    int focusCounter = 0;
    enum forceStates {idle, ongoing, ready, delayed, failed};
    forceStates forceState = forceStates.idle;
    string forceCombination = "";
    const string pushCombination = "qwe";
    const string teleportCombination = "qwas";

    bool restarting = false;

    void Awake()
    {
	focusLight = Instantiate(focusLight, new Vector3(10, 0, 0), Quaternion.identity);//Position X may cause problems at start
	moves = GetComponent<Moves>();
	powers = GetComponent<Powers>();
        indicator = focusStateIndicator.GetComponent<SpriteRenderer>();
    }
	
    void Update()
    {
	if (!restarting && moves.dead)
	{
	    restarting = true;
	    StartCoroutine(restart());
	}

	//Boundaries
	if (transform.position.x <= leftEnd)
	    transform.position = new Vector2(leftEnd, transform.position.y);
	if (transform.position.y <= bottomEnd)
	    transform.position = new Vector2(transform.position.x, bottomEnd);
	if (transform.position.x >= rightEnd)
	    transform.position = new Vector2(rightEnd, transform.position.y);

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
		    //Debug.Log("Delayed");
		    indicator.color = Color.magenta;
		    forceCombination = "";
		}
		else if (forceCombination == teleportCombination)
		{
		    powers.teleport();
		    forceState = forceStates.idle;
		    //Debug.Log("Idle");
		    indicator.color = new Color(0, 0, 0, 0);
		    forceCombination = "";
		}
	    }
	}

	//Track force powers
	if (forceState != forceStates.delayed)
	{
	    if (Input.GetKeyDown(KeyCode.Q))
	    {
		focusCounter = 0;
		forceState = forceStates.ongoing;
		forceCombination += "q";
		//Debug.Log("Ongoing: " + forceCombination);
		indicator.color = Color.yellow;
	    }
	    else if (Input.GetKeyDown(KeyCode.W))
	    {
		focusCounter = 0;
		forceState = forceStates.ongoing;
		forceCombination += "w";
		//Debug.Log("Ongoing: " + forceCombination);
		indicator.color = Color.yellow;
	    }
	    else if (Input.GetKeyDown(KeyCode.E))
	    {
		focusCounter = 0;
		forceState = forceStates.ongoing;
		forceCombination += "e";
		//Debug.Log("Ongoing: " + forceCombination);
		indicator.color = Color.yellow;
		if (forceCombination == pushCombination)
		{
		    forceState = forceStates.ready;
		    //Debug.Log("Push Ready");
		    indicator.color = Color.blue;
		}
	    }
	    else if (Input.GetKeyDown(KeyCode.A))
	    {
		focusCounter = 0;
		forceState = forceStates.ongoing;
		forceCombination += "a";
		//Debug.Log("Ongoing: " + forceCombination);
		indicator.color = Color.yellow;
	    }
	    else if (Input.GetKeyDown(KeyCode.S))
	    {
		focusCounter = 0;
		forceState = forceStates.ongoing;
		forceCombination += "s";
		//Debug.Log("Ongoing: " + forceCombination);
		indicator.color = Color.yellow;
		if (forceCombination == teleportCombination)
		{
		    forceState = forceStates.ready;
		    //Debug.Log("Teleport Ready");
		    indicator.color = Color.blue;
		}
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
		//Debug.Log("Failed");
		indicator.color = Color.red;
	    }
	}
	if (forceState == forceStates.failed)
	{
	    focusCounter++;
	    if (focusCounter >= 30)
	    {
		focusCounter = 0;
		forceState = forceStates.idle;
		//Debug.Log("Idle");
		indicator.color = new Color(0, 0, 0, 0);
	    }
	}
	if (forceState == forceStates.delayed)
	{
	    focusCounter++;
	    if (focusCounter >= 50)
	    {
		focusCounter = 0;
		forceState = forceStates.idle;
		//Debug.Log("Idle");
		indicator.color = new Color(0, 0, 0, 0);
	    }
	}
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
	if (collision.transform.CompareTag("Enemy"))
	    moves.dead = true;
    }
    
    IEnumerator restart()
    {
	yield return new WaitForSeconds(2.0f);
	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
