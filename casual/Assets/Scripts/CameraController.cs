using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target; // object to look at and follow
    [SerializeField] float sensitivity;
    [SerializeField] float speed;
    [SerializeField] float distance;

    private float Pitch;
    private float Yaw;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        Pitch += Input.GetAxis("Mouse X");
        Yaw -= Input.GetAxis("Mouse Y");

        Yaw = Mathf.Clamp(Yaw, -90f, 90f);
    }

    private void LateUpdate()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        transform.position = target.position + offset;
        transform.eulerAngles = new Vector3(Yaw, Pitch, 0.0f) * sensitivity;
        transform.localRotation = Quaternion.Euler(Pitch, Yaw, 0);
        transform.eulerAngles = new Vector2(Yaw, Pitch);
    }
}
