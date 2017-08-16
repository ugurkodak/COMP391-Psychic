using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint2 : MonoBehaviour
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
	    checkpoint.instantiateEnemy(checkpoint.forceUser, new Vector2(80.2f, 13.5f));
	    checkpoint.instantiateEnemy(checkpoint.fewMidichlorians, new Vector2(95.0f, 0.54f));
	    Destroy(checkpoint);
	    Destroy(this);
	}
    }
}
