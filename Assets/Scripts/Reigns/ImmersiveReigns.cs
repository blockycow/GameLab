using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ImmersiveReigns : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private Transform dragonTransform;
    [SerializeField] private float speedSensitivity;
    [SerializeField] private float acceleration; 
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float playerRotationSpeed = 1.0f;
    [SerializeField] private Transform grabbableReigns;
    [SerializeField] private Transform pivot;
    [SerializeField] private float deadZone;
    
    private CharacterController characterController;

    private float currentSpeed = 0;
    
    void Start()
    {
        characterController = targetTransform.GetComponent<CharacterController>();
    }
    
    private void Update()
    {
        var height = grabbableReigns.localPosition.y;
        
        // Map the height to a rotation angle
        float targetRotationAngle = Mathf.Lerp(-25, 25, Mathf.InverseLerp(0.5f, -0.5f, height));

        // Calculate the target rotation based on the angle
        Quaternion targetRotation = Quaternion.Euler(targetRotationAngle, 0f, grabbableReigns.localEulerAngles.z);
        dragonTransform.localRotation = Quaternion.Slerp(dragonTransform.localRotation, targetRotation, rotationSpeed);
        var dragonTransformEulerAngles = dragonTransform.localEulerAngles;
        
        if (dragonTransformEulerAngles.z > 300) { dragonTransformEulerAngles.z -= 360; }
        dragonTransformEulerAngles.z = Mathf.Clamp(dragonTransformEulerAngles.z , -35, 35);

        dragonTransform.localRotation = Quaternion.Euler(dragonTransformEulerAngles);
        characterController.transform.Rotate(0,-dragonTransformEulerAngles.z * Time.deltaTime * playerRotationSpeed,0);
    }
    
    void FixedUpdate()
    {
        var heading = grabbableReigns.localPosition;
        if(CheckDeadzone())
        {
            if (currentSpeed > 0)
            {
                currentSpeed -= (acceleration * 3);
            }
            else
            {
                currentSpeed = 0;
            }
        }
        
        
        if (currentSpeed < speedSensitivity)
        {
            currentSpeed += acceleration;
        } 
        else if (currentSpeed > speedSensitivity)
        {
            currentSpeed = speedSensitivity;
        }
            
        heading = grabbableReigns.localPosition - pivot.localPosition;
        heading = new Vector3(0f, heading.y, heading.z);
        var moveSpeed = heading.z * currentSpeed;
        var globalDir = characterController.transform.TransformDirection(Vector3.forward);
        characterController.Move(globalDir * moveSpeed);
        characterController.Move(new Vector3(0, heading.y, 0) * currentSpeed);
    }

    bool CheckDeadzone()
    {
        float distance = Vector3.Distance(grabbableReigns.position, pivot.position);

        return distance < deadZone;
    }
}
