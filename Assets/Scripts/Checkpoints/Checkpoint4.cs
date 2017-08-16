using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint4 : MonoBehaviour
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
	    checkpoint.instantiateEnemy(checkpoint.forceUser, new Vector2(138.0f, 13.5f));
	    checkpoint.instantiateEnemy(checkpoint.fewMidichlorians, new Vector2(152.3f, 0.54f));
	    checkpoint.instantiateEnemy(checkpoint.fewMidichlorians, new Vector2(165.0f, 0.54f));
	    checkpoint.instantiateEnemy(checkpoint.fewMidichlorians, new Vector2(118.0f, 0.54f));
	    checkpoint.instantiateEnemy(checkpoint.fewMidichlorians, new Vector2(105.0f, 0.54f));
	    Destroy(checkpoint);
	    Destroy(this);
	}
    }
}
