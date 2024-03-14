using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Weapon : GameUnit
{
    protected float rotationSpeed = 10f;
    public Vector3 target;
    public int plusExp;
    protected float weaponSpeed = 10f;  
    public Character character;
    public float distance = 12f;
    protected Weapon weapon;
    protected Vector3 pointChar;
    [SerializeField] protected GameObject skinWeapon;
    private void Start()
    {
        weapon = this;
        pointChar = character.transform.position;       
    }
    public virtual void Update()
    {
        
    }
    protected void MoveToTarget()
    {              
        transform.Translate(transform.forward * weaponSpeed * Time.deltaTime); 
    }
    public int GetLevelChar( int curLevelChar)
    {
        if(curLevelChar >= 0)
        {
            plusExp = 1;
        }
        return plusExp;
    }

    private void OnTriggerEnter(Collider other)
    {
        Character charaterTarget = other.GetComponent<Character>();
        if (charaterTarget != null)
        {
            GetLevelChar(charaterTarget.currentLevel);
            character.IncreaseLevel(plusExp);
            if (charaterTarget is Bot)
            {
                Bot bot = other.GetComponent<Bot>();
                SimplePool.Despawn(bot.targetIndicator);
                SimplePool.Despawn(bot);
            }
        }
    }
    protected void DespawnWeapon()
    {     
        SimplePool.Despawn(weapon);
    }
}
