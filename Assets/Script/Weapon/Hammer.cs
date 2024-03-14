using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Hammer : Weapon
{
    public override void Update()
    {
        base.Update();
        DespawnHammer();
    }
    private void DespawnHammer()
    {      
        MoveToTarget();
        skinWeapon.transform.Rotate(Vector3.forward * rotationSpeed);
        if (Vector3.Distance(transform.position, pointChar) > distance)
        {
            DespawnWeapon();
        }
    }
}
