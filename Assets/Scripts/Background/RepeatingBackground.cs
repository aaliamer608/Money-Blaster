using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

    private BoxCollider2D backCollider;
    private float backHorizontalLength;

	// Use this for initialization
	void Start () {
        backCollider = GetComponent<BoxCollider2D>();
        backHorizontalLength = backCollider.size.x;

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.x < -backHorizontalLength)
        {
            repositionBack();
        }
	}

    private void repositionBack ()
    {
        Vector2 backOffsetHor = new Vector2(backHorizontalLength * 2f, 0);
        transform.position = (Vector2)transform.position + backOffsetHor;

    }
}
