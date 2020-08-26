using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CounterGravity : MonoBehaviour
{
    private Rigidbody body;                                                //Create refrence.
    
    private void Awake()
    {
        body = GetComponent<Rigidbody>();                                  //Gets the rigid body component.  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //sets the object mass to that of the rigidbody
        //With this you can change the mass in the editor 
        //and still be in the air.
        body.AddForce(-Physics.gravity.y * body.mass * Vector3.up);           //Gravity * rigidbody mass * vector up.
    }
}
