using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{  
    [SerializeField] private float speed = 5f;
  
    protected override void Update()
    {
        base.Update();
        CheckCharacter();
        PlayerMove();     
    }
    private void PlayerMove()
    {
        if (Input.GetMouseButton(0) && isCanMove == true)
        {
            isShooting = true;
            Vector3 nextPoint = JoystickControl.direct * speed * Time.deltaTime + transform.position;
            transform.position = nextPoint;
            if (JoystickControl.direct != Vector3.zero)
            {
                skin.forward = JoystickControl.direct;
            }
            ChangeAnim("run");
        }
        if (Input.GetMouseButtonUp(0)  && isShooting)
        {
            skin.localRotation = Quaternion.identity;
                      
            ChangeAnim("attack");
            isShooting = false;
        }
       if(Input.GetMouseButtonUp(0) )
        {
            ChangeAnim("idle");
        }
    }
   
}
  


