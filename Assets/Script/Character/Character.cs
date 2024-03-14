using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class Character : Equipment
{    
    [SerializeField] private LayerMask layerCharacter;
    [SerializeField] protected Transform skin;
    public Animator anim;
    private string currentAnim = "idle";
    public GameObject aim;
    [SerializeField] protected GameObject deadEffect;
    private float deadTime = 0.8f;
    public Transform Myself;
    protected bool isShooting = false;  
    private int lastScaleLevel = 0;
    public int currentLevel = 0;
    private Vector3 currentScale;
    protected Weapon newWeapon;
    public bool isCanMove = false;
     
    protected virtual void Update()
    {
        UpdateLocal();      
    } 
    protected void CheckCharacter()
    {              
        Collider[] coliders = Physics.OverlapSphere(Myself.position, 12f, layerCharacter);  
        for (int i =0; i< coliders.Length; i++)
        {
            if(coliders.Length == 1)
            {
                aim.SetActive(false);
            }
            if (IsColiderMyself(coliders[i]))
            {
                continue;
            }
            Transform target = coliders[i].transform;

            transform.LookAt(target);
           
            if(this is Bot)
            {
                Player player = target.GetComponent<Player>();               
                if (player != null)
                {
                    aim.SetActive(true);
                }              
            }        
        }
    }
    private bool IsColiderMyself(Collider collider)
    {
        return collider.transform == transform;
    }
 
    public void IncreaseLevel(int level)
    {
        currentLevel += level;
    }
    private void UpdateLocal()
    {
        int i = 0;
        if (currentLevel >= 2 && lastScaleLevel < 2)
        {
            i = 1;
            skin.transform.position = new Vector3(transform.position.x,transform.position.y + i* 0.4f, transform.position.z);
            Vector3 newScale = new  Vector3(1f + i *0.2f, 1f + i * 0.2f, 1f + i* 0.2f);
            skin.localScale = newScale;
            lastScaleLevel = 2;          
        }
        if (currentLevel >= 6 && lastScaleLevel < 6)
        {
            i = 2;
            skin.transform.position = new Vector3(transform.position.x, transform.position.y + i * 0.4f, transform.position.z);
            Vector3 newScale = new Vector3(1f + i * 0.2f, 1f + i * 0.2f, 1f + i * 0.2f);
            skin.localScale = newScale;
            lastScaleLevel = 6;
        }
    }
    
    public void ChangeAnim(string animName)
    {
        if(currentAnim != animName)
        {
            anim.ResetTrigger(currentAnim);          
            currentAnim = animName;
            anim.SetTrigger(currentAnim);
        }  
    }
   
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(Myself.position, 8f);
    }
}
