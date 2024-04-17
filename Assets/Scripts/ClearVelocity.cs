using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void ResetAllVelocityKinematically()
    {
        print("release");
        rb.isKinematic = true;
        rb.isKinematic = false;
    }
    
    public void ResetAllVelocity()
    {
        print("release");
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    public void LockRotation()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
    
    public void UnlockRotation()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;
    }
}
