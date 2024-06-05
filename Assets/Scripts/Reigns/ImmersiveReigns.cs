using UnityEngine;

// The reigns controls for the immersive controls.
// Most of the code stays the same, except a few lines
// -Nemo
public class ImmersiveReigns : BaseReigns
{
    [SerializeField] private float playerRotationSpeed = 1.5f;
    
    protected override void Start()
    {
        base.Start();
    }
    
    // Set the rotation angle of the dragon to the height of the reigns.
    // Set the movement rotation of the player based on the angle of the reigns
    protected override void Update()
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
    
    // The same as the base function
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
