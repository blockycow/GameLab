using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A class that clears the velocity on certain objects,
// only when its functions get called.
// -Nemo
public class ClearVelocity : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    private void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    // Stops the velocity by setting the rigidbody to kinematic for one frame.
    public void ResetAllVelocityKinematically()
    {
        rb.isKinematic = true;
        rb.isKinematic = false;
    }
    
    // Stops the velocity by setting both the regular and angular velocity to zero.
    public void ResetAllVelocity()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    // Freezes the rotation on any axis.
    public void LockRotation()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
    
    // Unlocks the rotation on the necessary axes.
    public void UnlockRotation()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;
    }
}
