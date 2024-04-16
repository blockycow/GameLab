using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionClamper : MonoBehaviour
{
    [SerializeField] private Transform clampTransform;
    
    [SerializeField] private Vector3 clampPosition;

    //[SerializeField] private bool local;

    private void Start()
    {
        if (clampTransform == null) clampTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current position of the object
        Vector3 currentPosition = clampTransform.localPosition;

        // Clamp the x, y, and z coordinates of the current position
        float clampedX = Mathf.Clamp(currentPosition.x, -clampPosition.x, clampPosition.x);
        float clampedY = Mathf.Clamp(currentPosition.y, -clampPosition.y, clampPosition.y);
        float clampedZ = Mathf.Clamp(currentPosition.z, -clampPosition.z, clampPosition.z);

        // Set the clamped position to the object
        clampTransform.localPosition = new Vector3(clampedX, clampedY, clampedZ);
    }
}
