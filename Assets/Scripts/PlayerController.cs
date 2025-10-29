using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Transform orientation;
    private float xInput;
    private float yInput;
    private Vector3 movingDirection;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Read input (keyboard)
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
        // Calculate correct direction
        movingDirection = orientation.forward * yInput + orientation.right * xInput;
        // Move to correct direction
        rb.AddForce(movingDirection.normalized * speed, ForceMode.Force);
        // Do not exceed maximum speed
        Vector3 groundVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        if (groundVelocity.magnitude > speed)
        {
            Vector3 maxVelocity = groundVelocity.normalized * speed;
            rb.linearVelocity = new Vector3(maxVelocity.x, rb.linearVelocity.y, maxVelocity.z);
        }
    }
}
