using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;

    public float smoothSpeed = 0.125f; //higher means faster camera between 0 and 1
    public Vector3 offset;


    void FixedUpdate()
    {
        Vector3 positionWanted = target.position + offset;
//        Vector3 smoothedPosition = Vector3.Lerp(transform.position,target.position, smoothSpeed);

        transform.position = positionWanted;

        transform.LookAt(target);
    }

}
