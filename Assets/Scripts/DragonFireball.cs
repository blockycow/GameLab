using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragonFireball : MonoBehaviour
{
    [SerializeField] private float force = 5f;
    [SerializeField] private InputActionReference triggerAction;
    [SerializeField] private Transform barrel;
    [SerializeField] private Fireball fireball;

    private void Update()
    {
        if (triggerAction.action.triggered)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        var ball = Instantiate(fireball, barrel.position, barrel.rotation);
        ball.GetComponent<Rigidbody>().AddForce(barrel.forward * force, ForceMode.Impulse);
    }
}
