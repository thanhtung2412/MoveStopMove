using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offet;
    [SerializeField] private float speed = 5f;
    public bool isCanFollowTarget = false;
   
    void LateUpdate()
    {
        if (target != null && isCanFollowTarget == true)
        {
            transform.rotation = Quaternion.Euler(new Vector3(70, 0, 0));
            transform.position = Vector3.Lerp(transform.position, target.position + offet, speed * Time.deltaTime);
        }
        
    }
}
