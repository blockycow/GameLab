using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
