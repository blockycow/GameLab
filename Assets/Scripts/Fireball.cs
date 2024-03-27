using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] float radius = 20.0F;
    [SerializeField] private GameObject explosionObj;
    private void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("BAM");
        var explosion = Instantiate(explosionObj, transform.position, quaternion.identity);
        explosion.transform.localScale = new Vector3(radius/3.0f, radius/3.0f, radius/3.0f);
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

        foreach (Collider hit in colliders)
        {
            if (hit.GetComponent<ICollidable>() != null)
            {
                hit.GetComponent<Rigidbody>().AddExplosionForce(5, explosionPos, radius, 5, ForceMode.Impulse);
            }
        }
        Destroy(this.gameObject);
    }
    
}
