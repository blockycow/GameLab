using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Reigns : MonoBehaviour
{
    [SerializeField] private float speedAdjustment;
    [SerializeField] private Transform grabbableReigns;
    [SerializeField] private Transform pivot;
    
    CharacterController characterController;
    
    // Start is called before the first frame update
    void Start()
    {
        characterController = GameObject.FindWithTag("Player").GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Gets a vector that points from the pivot's position to the reign's.
        var heading = grabbableReigns.position - pivot.position;
        if(heading == Vector3.zero) return;
        characterController.Move(heading * speedAdjustment);
    }
}
