using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint1 : MonoBehaviour
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
	    checkpoint.instantiateEnemy(checkpoint.fewMidichlorians, new Vector2(61.0f, 0.54f));
	    checkpoint.instantiateEnemy(checkpoint.fewMidichlorians, new Vector2(66.8f, 0.54f));
	    Destroy(checkpoint);
	    Destroy(this);
	}
    }
}
