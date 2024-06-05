using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The reigns controls for the standard controls.
// -Nemo
public class BaseReigns : MonoBehaviour
{
    [SerializeField] protected Transform targetTransform;
    [SerializeField] protected Transform dragonTransform;
    [SerializeField] protected float speedSensitivity;
    [SerializeField] protected float acceleration; 
    [SerializeField] protected float rotationSpeed;
    [SerializeField] protected Transform grabbableReigns;
    [SerializeField] protected Transform pivot;
    [SerializeField] protected float deadZone;
    
    protected CharacterController characterController;
    
    protected float currentSpeed = 0;
    
    protected virtual void Start()
    {
        characterController = targetTransform.GetComponent<CharacterController>();
    }
    
    // Set the rotation angle of the dragon to the height of the reigns.
    protected virtual void Update()
    {
        var height = grabbableReigns.localPosition.y;
        
        // Map the height to a rotation angle
        float targetRotationAngle = Mathf.Lerp(-25, 25, Mathf.InverseLerp(0.5f, -0.5f, height));

        // Calculate the target rotation based on the angle
        Quaternion targetRotation = Quaternion.Euler(targetRotationAngle, 0f, 0f);
        dragonTransform.localRotation = Quaternion.Slerp(dragonTransform.localRotation, targetRotation, rotationSpeed);
        var dragonTransformEulerAngles = dragonTransform.localEulerAngles;
        
        dragonTransform.localRotation = Quaternion.Euler(dragonTransformEulerAngles);
    }
    
    // Changes the player movement direction based on the position of the reigns.
    // Changes the speed of movement also on the reigns position.
    protected virtual void FixedUpdate()
    {
        var heading = grabbableReigns.localPosition;
        if(CheckDeadzone()) {
            if (currentSpeed > 0) { currentSpeed -= (acceleration * 3); }
            else { currentSpeed = 0; }
        }
        
        if (currentSpeed < speedSensitivity) { currentSpeed += acceleration; } 
        else if (currentSpeed > speedSensitivity) { currentSpeed = speedSensitivity; }
            
        heading = grabbableReigns.localPosition - pivot.localPosition;
        heading = new Vector3(0f, heading.y, heading.z);
        var moveSpeed = heading.z * currentSpeed;
        var globalDir = characterController.transform.TransformDirection(Vector3.forward);
        characterController.Move(globalDir * moveSpeed);
        characterController.Move(new Vector3(0, heading.y, 0) * currentSpeed);
    }

    // Check if the reigns are in the dead zone.
    protected bool CheckDeadzone()
    {
        float distance = Vector3.Distance(grabbableReigns.position, pivot.position);

        return distance < deadZone;
    }
    
    // Reset the position of the reigns after letting go.
    public void ResetReignsPosition()
    {
        grabbableReigns.localPosition = Vector3.zero;
        grabbableReigns.localRotation = Quaternion.identity;
    }
}