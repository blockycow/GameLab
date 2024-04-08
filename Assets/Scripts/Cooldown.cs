using System;
using UnityEngine;

[Serializable]
public class Cooldown
{
    [SerializeField] private float cooldownTime;
    private float nextFireTime;

    public bool IsCoolingDown => Time.time < nextFireTime;
    public void StartCooldown() => nextFireTime = Time.time + cooldownTime;
    
}
