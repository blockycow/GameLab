using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class Reigns : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private Transform dragonTransform;
    [SerializeField] private float speedSensitivity;
    [SerializeField] private float flySpeedSensitivity;
    [SerializeField] private float acceleration; 
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform grabbableReigns;
    [SerializeField] private Transform pivot;
    [SerializeField] private float deadZone;

    [SerializeField] private InputActionReference FlyToggleAction;
    private bool flying;
    private Rigidbody rb;
    private CharacterController characterController;

    private float currentSpeed = 0;
    
    void Start()
    {
        //rb = targetTransform.GetComponent<Rigidbody>();
        characterController = targetTransform.GetComponent<CharacterController>();
    }
    
    private void Update()
    {
        flying = FlyToggleAction.action.inProgress;
        
        var height = grabbableReigns.localPosition.y;
        
        // Map the height to a rotation angle
        float targetRotationAngle = Mathf.Lerp(-25, 25, Mathf.InverseLerp(0.5f, -0.5f, height));

        // Calculate the target rotation based on the angle
        Quaternion targetRotation = Quaternion.Euler(targetRotationAngle, 0f, 0f);
        dragonTransform.localRotation = Quaternion.Slerp(dragonTransform.localRotation, targetRotation, rotationSpeed);
        var dragonTransformEulerAngles = dragonTransform.localEulerAngles;
        
        dragonTransform.localRotation = Quaternion.Euler(dragonTransformEulerAngles);
    }
    
    void FixedUpdate()
    {
        var heading = grabbableReigns.localPosition;
        if(CheckDeadzone())
        {
            if (currentSpeed > 0)
            {
                currentSpeed -= (acceleration * 2);
            }
            else
            {
                currentSpeed = 0;
            }
        }
        
        if (flying)
        {
            //characterController.transform.Rotate(new Vector3(0, heading.x * rotationSpeed,0));
            if (currentSpeed < flySpeedSensitivity)
            {
                currentSpeed += acceleration;
            } else if (currentSpeed > flySpeedSensitivity)
            {
                currentSpeed = flySpeedSensitivity;
            }
            
            //TODO increase flight speed with reigns position
            heading = new Vector3(0, heading.y, heading.z);
            characterController.Move((transform.forward) * currentSpeed);
            //rb.AddForce((transform.forward) * flySpeedSensitivity);
            //targetTransform.Translate((transform.forward) * flySpeedSensitivity);
        }
        else
        {
            if (currentSpeed < speedSensitivity)
            {
                currentSpeed += acceleration;
            } 
            else if (currentSpeed > speedSensitivity)
            {
                currentSpeed = speedSensitivity;
            }
            
            heading = grabbableReigns.position - pivot.position;
            characterController.Move(heading * currentSpeed);
            //rb.AddForce(heading * speedSensitivity);
            //targetTransform.Translate(heading * speedSensitivity);
        }
    }

    bool CheckDeadzone()
    {
        float distance = Vector3.Distance(grabbableReigns.position, pivot.position);

        return distance < deadZone;
    }
}