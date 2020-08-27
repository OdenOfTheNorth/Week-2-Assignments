using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public CharacterController controller;
    public float moveSpeed = 12f;

    private Gun gun;
    
    private void Awake()
    {
        //gun = GetComponent<Gun>();
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(moveSpeed * Time.deltaTime * move);
    }
}
