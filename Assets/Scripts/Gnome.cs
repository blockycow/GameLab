using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gnome : MonoBehaviour, ICollidable
{
    [SerializeField] private Rigidbody rb;
    //[SerializeField] float torqueMagnitude = 5f;
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
}
