using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contr : MonoBehaviour
{
    public float speed;
    public float gravity;
    public float jumpHeight;
    public LayerMask ground;
    public Transform player;
    private Rigidbody rb;

    private Vector3 direction;
    private Vector3 walkingVelocity;
    private Vector3 fallingVelocity;
    private CharacterController controller;

    // Use this for initialization

    void Start()
    {
        gravity = 9.8f;
        jumpHeight = 3.0f;
        direction = Vector3.zero;
        fallingVelocity = Vector3.zero;
        controller = GetComponent<CharacterController>();
    }



    // Update is called once per frame

    void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        direction = direction.normalized;
        walkingVelocity = direction * speed;
        controller.Move(walkingVelocity * Time.deltaTime);

        if (direction != Vector3.zero)
        {
            transform.forward = direction;
            Debug.Log(direction);
        }

        bool isGrounded = Physics.CheckSphere(player.position, 0.1f, ground, QueryTriggerInteraction.Ignore);

        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            rb.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }
        if (controller.isGrounded)
            fallingVelocity.y = 0f;
        else
            fallingVelocity.y -= gravity * Time.deltaTime;
   
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            fallingVelocity.y = Mathf.Sqrt(gravity * jumpHeight);
        }
        controller.Move(fallingVelocity * Time.deltaTime);
    }
}
