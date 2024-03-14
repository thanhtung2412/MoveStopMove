using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Candy : Weapon
{
    public override void Update()
    {
        base.Update();
        DespawnCandy();
    }
    private void DespawnCandy()
    {
        MoveToTarget();
        skinWeapon.transform.localRotation = character.transform.localRotation;
        if (Vector3.Distance(transform.position, pointChar) > distance)
        {
            DespawnWeapon();
        }
    }  
}
