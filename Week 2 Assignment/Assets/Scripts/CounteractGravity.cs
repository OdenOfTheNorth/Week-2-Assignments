using UnityEngine;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(Rigidbody))]
public class CounteractGravity : MonoBehaviour
{
    public float counterGravity = 9.81f;                                   //Unitys gravity. see projekt settings physics.
    public float speed = 0;
    
    private Rigidbody body;                                                //Create refrence.
    private float objectMass = 0.0f;                                       //Create Object mass refrence.
    
    private void Awake()
    {
        body = GetComponent<Rigidbody>();                                  //Gets the rigid body component.  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        objectMass = body.mass;                                            //sets the object mass to that of the rigidbody
                                                                           //With this you can change the mass in the editor 
                                                                           //and still be in the air.
        body.AddForce(counterGravity * objectMass * Vector3.up);           //Gravity * rigidbody mass * vector up.
    }
}
