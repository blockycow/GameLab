using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Shoot out a fireball to hit the gnomes with.
// -Channah
public class DragonFireball : MonoBehaviour
{
    [SerializeField] private float force = 5f;
    [SerializeField] private InputActionReference triggerAction;
    [SerializeField] private Transform barrel;
    [SerializeField] private Fireball fireball;

    private void Update()
    {
        // Shoot when pressing a specific button.
        if (triggerAction.action.triggered)
        {
            Shoot();
        }
    }

    // Create a fireball.
    private void Shoot()
    {
        var ball = Instantiate(fireball, barrel.position, barrel.rotation);
        ball.GetComponent<Rigidbody>().AddForce(barrel.forward * force, ForceMode.Impulse);
    }
}
