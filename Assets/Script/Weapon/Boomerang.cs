using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boomerang : Weapon
{
 
    public override void Update()
    {
        base.Update();
        DespawnBoomerang();
    }
    private void DespawnBoomerang()
    {
        MoveToTarget();
        skinWeapon.transform.Rotate(Vector3.forward * rotationSpeed);
        if (Vector3.Distance(transform.position, pointChar) > distance)
        {
            transform.position = Vector3.MoveTowards(transform.position, character.transform.position, weaponSpeed);
            if(Vector3.Distance(transform.position,character.transform.position) < 0.5f)
            {
                DespawnWeapon();
            }
        }
    }
    
}
