using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

// The collision for when the dragon hits the gnome.
// -Frieda
public class Gnome : MonoBehaviour, ICollidable
{
    [SerializeField] private Rigidbody rb;
    
    // Add a random force to the velocities of the gnome.
    public void Collide(Collider collision, float force)
    {
        var forceSpread = force / 2.0f;
        rb.AddForce(new Vector3(
            Random.Range(-forceSpread, forceSpread),
            force,
            Random.Range(-forceSpread, forceSpread)), ForceMode.Impulse);
        
        Vector3 torque = Random.insideUnitSphere * force;
        rb.AddTorque(torque, ForceMode.Impulse);
    }

    // delete is the gnome falls too low.
    private void Update()
    {
        if (transform.position.y > -5000) return;
        
        Destroy(this);
    }
}
