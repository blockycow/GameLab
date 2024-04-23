using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandRaycast : MonoBehaviour
{
    [SerializeField] private float force = 5f;
    [SerializeField] private InputActionReference triggerAction;
    [SerializeField] private Transform barrel;
    [SerializeField] private Fireball fireball;
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            if (triggerAction.action.triggered)
            {
                Shoot(hit.point);
            }
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }
    

    private void Shoot(Vector3 rayHit)
    {
        var ball = Instantiate(fireball, barrel.position, barrel.rotation);
        //ball.GetComponent<Rigidbody>().AddForce((rayHit - this.transform.position).normalized * force, ForceMode.Impulse);
        ball.GetComponent<Rigidbody>().velocity = (rayHit - this.transform.position).normalized * force;
    }
}
