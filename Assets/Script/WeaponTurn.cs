using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTurn : MonoBehaviour
{
    public float speedTurn = 200f;
    void Update()
    {
        transform.Rotate(Vector3.up * speedTurn * Time.deltaTime);
    }
}
