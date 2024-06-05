using System;
using System.Collections;
using System.Collections.Generic;
using BNG;
using UnityEngine;
using UnityEngine.InputSystem;

// This class is responsible for resetting the player view.
// -Nemo
public class RecenterView : MonoBehaviour
{
    [SerializeField] private Transform head;
    [SerializeField] private Transform origin;
    [SerializeField] private Transform target;

    // Recenter when the game starts
    private void Start()
    {
        Recenter();
    }

    void Update()
    {
        if (InputBridge.Instance.AButtonDown)
        {
            Recenter();
        }
    }

    // Recenter the view based on the floor.
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
