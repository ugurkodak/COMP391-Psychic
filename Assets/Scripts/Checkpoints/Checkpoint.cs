using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Transform player;
    public Transform forceUser;
    public Transform fewMidichlorians;
    
    public bool init = false;
    public bool done = false;
    
    void Update()
    {
	if (!init && player.position.x >= transform.position.x)
	    init = true;
    }

    public void instantiateEnemy(Transform type, Vector2 position)
    {
	Instantiate(type, new Vector3(position.x, position.y, 0), Quaternion.identity);	
    }
}
