using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clamps the position so the object doesn't go out of reach.
// -Nemo
public class PositionClamper : MonoBehaviour
{
    [SerializeField] private Transform clampTransform;
    [SerializeField] private Vector3 clampPosition;

    private void Start()
    {
        if (clampTransform == null) clampTransform = this.transform;
    }

    // Makes sure the position stays between the bounds
    void Update()
    {
        Vector3 currentPosition = clampTransform.localPosition;
        float clampedX = Mathf.Clamp(currentPosition.x, -clampPosition.x, clampPosition.x);
        float clampedY = Mathf.Clamp(currentPosition.y, -clampPosition.y, clampPosition.y);
        float clampedZ = Mathf.Clamp(currentPosition.z, -clampPosition.z, clampPosition.z);

        clampTransform.localPosition = new Vector3(clampedX, clampedY, clampedZ);
    }
}
