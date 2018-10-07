using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}


public class Movement : MonoBehaviour {

    public float speed;
    public Boundary boundary;

    private Rigidbody rbd;

    private void Start()
    {
        rbd = GetComponent<Rigidbody> ();
    }

    void FixedUpdate()
    {
      //  float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(0.0f, moveVertical);

        rbd.velocity = (movement * speed);

        GetComponent<Rigidbody>().position = new Vector3 (
            Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            
            Mathf.Clamp (GetComponent<Rigidbody>().position.y, boundary.yMin, boundary.yMax));
    }
}
