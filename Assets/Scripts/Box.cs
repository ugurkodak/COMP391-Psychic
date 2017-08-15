using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    Rigidbody2D rBody;
    
    public Transform canvas = null;
    public string hint;
    bool pushed = false;

    void Awake()
    {
	rBody = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
	if (rBody.velocity.magnitude > 15.0f)
	{
	    if (canvas)
		canvas.GetChild(0).GetComponent<Text>().text = "";
	    Destroy(gameObject, 1);	
	}
    }
    
    void OnMouseOver()
    {
        if (hint != "" && canvas)
	{
	    canvas.position = new Vector2(transform.position.x, transform.position.y + 7);
	    canvas.GetChild(0).GetComponent<Text>().text = hint;
	}
    }

    void OnMouseExit()
    {
	if (canvas)
	    canvas.GetChild(0).GetComponent<Text>().text = "";
    }
}
