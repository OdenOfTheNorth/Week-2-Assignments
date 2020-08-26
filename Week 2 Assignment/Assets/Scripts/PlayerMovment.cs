using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public CharacterController controller;
    
    public float speed = 12f;
    public float gravity = -9.81f;
    public float JumpHeight = 3f;

    public Transform groundcheak;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private const int MAX_JUMP = 2;
    private int currentJump = 0;

    Vector3 velocity;
    bool isGrounded;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundcheak.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            currentJump = 0;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (Input.GetKey("left shift")) 
        {
            x = x * 2;
            z = z * 2;
        }
        
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && (isGrounded || MAX_JUMP > currentJump))
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
            currentJump++;
        }
        

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
