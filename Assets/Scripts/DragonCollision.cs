using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Using the collision interface, collide with certain objects.
// -Elif
public class DragonCollision : MonoBehaviour
{
    [SerializeField] private float collisionForce = 5.0f;
    
    private void OnTriggerEnter(Collider other)
    {
        var collidable = other.GetComponent<ICollidable>();
        if (collidable != null)
        {
            collidable.Collide(other, collisionForce);
        }
    }
}
