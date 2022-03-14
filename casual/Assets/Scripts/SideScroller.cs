using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScroller : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;

    [SerializeField]
    private float clampXDir;
    private float horizontalInput;

    private Rigidbody rb;

    private Vector3 movement;



    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(GameManager.Instance.gameOver)
            return;
        horizontalInput = Input.GetAxisRaw("Horizontal");

        movement = new Vector3(horizontalInput, 0.0f, 0.0f);

        LookAtDirection();

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -clampXDir, clampXDir), transform.position.y, transform.position.z);

    }

    void LookAtDirection()
    {
        if (movement.magnitude >= 0.5f)
            transform.rotation = Quaternion.LookRotation(movement, Vector3.up);
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.gameOver)
            return;
        rb.MovePosition(transform.position + movement * speed * Time.deltaTime);
    }
}
