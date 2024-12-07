using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    float speed = 5f;
    float jumpForce = 5f;
    public Transform groundCheck;
    float groundCheckRadius = 0.5f;
    public LayerMask groundLayer;
    bool isGrounded;
    float yCheck;
    void Start()
    {
        yCheck = groundCheck.position.y;
        rb = GetComponent<Rigidbody>();
    }
    void Jump()
    {
        rb.AddForce (Vector3.up * jumpForce, ForceMode.Impulse);
        Debug.Log("Jumping done");
    }
    void Update()
    {
        //isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(x, 0f, z);
        rb.AddForce(movement * speed, ForceMode.Force);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
        Vector3 fixedGroundCheckPosition = groundCheck.position;
        fixedGroundCheckPosition.y = yCheck;
        groundCheck.position = fixedGroundCheckPosition;
    }
    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Island")
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Island")
        {
            isGrounded = false;
        }
    }
}
