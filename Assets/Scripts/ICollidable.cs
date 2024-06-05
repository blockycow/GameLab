using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// interface for the collisions.
// -Elif
public interface ICollidable
{
    void Collide(Collider collision, float force);
}
