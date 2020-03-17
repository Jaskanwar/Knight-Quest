using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float pitch = 2f;
    public float zoomspeed = 4f;
    public float maxZoom = 25f;
    public float minZoom = 5f;
    public float yawSpeed = 200f;
    public float currentYaw = 0f;


    private float currentZoom = 10f;

    void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomspeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
        currentYaw += Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;

    }

    void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);
        transform.RotateAround(target.position, Vector3.up, currentYaw);
    }
    
}
