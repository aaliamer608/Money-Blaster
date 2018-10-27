using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}


public class Movement : MonoBehaviour
{

    public float speed;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireDelta = 0.5F;

    private Rigidbody rbd;
    private float nextFire = .25f;
    private float fireRate = 0.0f;

    private void Start()
    {
        rbd = GetComponent<Rigidbody>();
    }

    void update()
    {
            if (Input.GetButton("Fire1") && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                GameObject clonedShot = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
            }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rbd.velocity = (movement * speed);

        GetComponent<Rigidbody>().position = new Vector2(
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),

            Mathf.Clamp(GetComponent<Rigidbody>().position.y, boundary.yMin, boundary.yMax));
    }
}
