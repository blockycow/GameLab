using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class Reigns : MonoBehaviour
{
    [SerializeField] private float speedSensitivity;
    [SerializeField] private float flySpeedSensitivity;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform grabbableReigns;
    [SerializeField] private Transform pivot;
    [SerializeField] private float deadZone;
    CharacterController characterController;

    [SerializeField] private InputActionReference FlyToggleAction;
    private bool flying;
    
    void Start()
    {
        characterController = GameObject.FindWithTag("Player").GetComponent<CharacterController>();
    }
    
    private void Update()
    {
        flying = FlyToggleAction.action.inProgress;
    }
    void FixedUpdate()
    {
        var heading = grabbableReigns.localPosition;
        if(!CheckDeadzone()) return;
        if (flying)
        {
            characterController.transform.Rotate(new Vector3(0, heading.x * rotationSpeed,0));
            
            //TODO increase flight speed with reigns position
            heading = new Vector3(0, heading.y, heading.z);
            characterController.Move((transform.forward) * flySpeedSensitivity);
        }
        else
        {
            heading = grabbableReigns.position - pivot.position;
            characterController.Move(heading * speedSensitivity);
        }
    }

    bool CheckDeadzone()
    {
        float distance = Vector3.Distance(grabbableReigns.position, pivot.position);

        return distance > deadZone;
    }
}
