using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    public Transform canvas;
    public string hint;
    bool pushed = false;
    
    void Update()
    {
	if (pushed)
	    Destroy(gameObject);
    }
    
    void OnMouseOver()
    {
        if (hint != "")
	{
	    canvas.position = new Vector2(transform.position.x, transform.position.y + 7);
	    canvas.GetChild(0).GetComponent<Text>().text = hint;
	}
    }

    void OnMouseExit()
    {
	canvas.GetChild(0).GetComponent<Text>().text = "";
    }
}
