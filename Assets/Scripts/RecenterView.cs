using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RecenterView : MonoBehaviour
{
    [SerializeField] private Transform head;
    [SerializeField] private Transform origin;
    [SerializeField] private Transform target;

    [SerializeField] private InputActionProperty recenterButton;
    
    // Update is called once per frame
    void Update()
    {
        if (recenterButton.action.WasPressedThisFrame())
        {
            print("pressed recenter button");
            Recenter();
        }
    }

    void Recenter()
    {
        Vector3 offset = head.position - origin.position;
        offset.y = 0;
        origin.position = target.position - offset;

        Vector3 targetForward = target.forward;
        targetForward.y = 0;
        Vector3 camForward = head.forward;
        camForward.y = 0;

        float angle = Vector3.SignedAngle(camForward, targetForward, Vector3.up);
        
        origin.RotateAround(head.position, Vector3.up, angle);
    }
}