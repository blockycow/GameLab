using System;
using UnityEngine;

// A class for anything that needs a cooldown.
// -Frieda
[Serializable]
public class Cooldown
{
    [SerializeField] private float cooldownTime;
    private float nextFireTime;

    public bool IsCoolingDown => Time.time < nextFireTime;
    public void StartCooldown() => nextFireTime = Time.time + cooldownTime;
    
}
