using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input : MonoBehaviour
{

    //private Movement movement;
    private HitscanShoot shot;

    
    private void Awake()
    {
        //movement = GetComponent<Movement>();
        shot = GetComponent<HitscanShoot>();

    }

    private void Update()
    {
        if (UnityEngine.Input.GetButtonDown("Fire1"))
        {
            shot.fire();
        }
    }
}
