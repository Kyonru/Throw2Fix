using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementController : MonoBehaviour
{

    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;
    public Camera mCamera;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target)
        {
            Vector3 point = mCamera.WorldToViewportPoint(target.position);
            Vector3 delta = target.position - mCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }

    }
}
