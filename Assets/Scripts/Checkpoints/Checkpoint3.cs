using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint3 : MonoBehaviour
{
    Checkpoint checkpoint;

    void Start()
    {
	checkpoint = GetComponent<Checkpoint>();
    }

    void Update()
    {
	if (!checkpoint.done && checkpoint.init)
	{
	    checkpoint.instantiateEnemy(checkpoint.forceUser, new Vector2(120.23f, 0.54f));
	    checkpoint.instantiateEnemy(checkpoint.fewMidichlorians, new Vector2(73.2f, 0.54f));
	    Destroy(checkpoint);
	    Destroy(this);
	}
    }
}
