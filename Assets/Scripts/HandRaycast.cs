using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Shoots fireballs to the point where the player points toward.
// This is the improved version of the DragonFireball script.
// -Channah
public class HandRaycast : MonoBehaviour
{
    [SerializeField] private float force = 5f;
    [SerializeField] private InputActionReference triggerAction;
    [SerializeField] private Transform barrel;
    [SerializeField] private Fireball fireball;
    
    void Update()
    {
        // Shoot out a raycast, if it hits something and if you push the button, shoot.
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            if (triggerAction.action.triggered)
            {
                Shoot(hit.point);
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        }
    }
    

    // Shoot a fireball to the direction of the raycast hit.
    private void Shoot(Vector3 rayHit)
    {
        var ball = Instantiate(fireball, barrel.position, barrel.rotation);
        ball.GetComponent<Rigidbody>().velocity = (rayHit - this.transform.position).normalized * force;
    }
}
