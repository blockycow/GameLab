using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] float radius = 20.0F;
    [SerializeField] private GameObject explosionObj;
    [SerializeField] private AudioClip FireBallSound;
    private void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);
        PlayFireBallSound();
        var explosion = Instantiate(explosionObj, transform.position, quaternion.identity);
        explosion.transform.localScale = Vector3.zero;
        explosion.transform.DOScale(radius / 3.0f, 0.2f).SetEase(Ease.OutCubic);
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

    private void PlayFireBallSound()
    {
        
    }
}
