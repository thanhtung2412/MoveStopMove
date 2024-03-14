using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Bot : Character
{
    private GameObject spawnPointArea;
    [SerializeField] private List<Vector3> pointSpawn = new List<Vector3>();  
   
    public NavMeshAgent agent;
    private int targetIndex = 0;
    private float timeMove = 5f; 
    private float timeStop = 3f; 
    private float timeCanShoot =0; 

    private float timer = 0f;
    private bool isMoving = true;
    private bool isBotMove = true;
    int rand;
    public TargetIndicator targetIndicator;
    public TargetIndicator targetIndicatorPrefabs;

    protected  void Start()
    {       
        CheckMap();
        rand = Random.Range(0, weaponBulletPrefabs.Length);
        AddTargetIndicator();
    }
  
 
    protected override void Update()
    {
        base.Update();
        CheckCharacter();
        targetIndicator.UpdateTargetIndicator();
        StartCoroutine(BotMove());         
       
    }
  
    protected void ShootingWithDelayBot()
    {                                             
        newWeapon = SimplePool.Spawn<Weapon>(weaponBulletPrefabs[Pref.CurWeaponID], boxContainBullet.position, Quaternion.identity);             
                //newWeapon.target = target;
        newWeapon.character = this;
        isBotMove = true;                  
    }   
    private IEnumerator BotMove()
    {
        if (isBotMove)
        {
            if (pointSpawn.Count > 0)
            {
                if (isMoving)
                {
                    
                    agent.SetDestination(pointSpawn[targetIndex]);
                    ChangeAnim("run");
                    if (agent.remainingDistance < 0.1f)
                    {
                        targetIndex = (targetIndex + 1) % pointSpawn.Count;
                    }
                    timer += Time.deltaTime;
                    if (timer >= timeMove)
                    {
                        isMoving = false;
                        timer = 0f;
                    }
                }
                else
                {
                    agent.isStopped = true;
                    ChangeAnim("idle");
                    yield return new WaitForSeconds(timeStop);
                    agent.isStopped = false;
                    isMoving = true;
                }
            }
        }
            yield return null;      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            isBotMove = false;
            Destroy(Instantiate(deadEffect, transform.position, Quaternion.identity), 0.5f);
            Destroy(other.gameObject);
            ChangeAnim("dead");                    
        }
        
    }
    private void CheckMap()
    {
        RaycastHit hit;
        if(Physics.Raycast(Myself.position, Vector3.down, out hit,5f ))
        {         
                spawnPointArea = hit.collider.gameObject;
                randomSpawnPoint();        
        }
    }
    public void AddTargetIndicator()
    {
        targetIndicator = SimplePool.Spawn<TargetIndicator>(targetIndicatorPrefabs, UIManager.Instance.boxIndicator.transform.position, UIManager.Instance.boxIndicator.transform.rotation);
        targetIndicator.InitialiseTargetIndicator(gameObject, UIManager.Instance.MainCamera, UIManager.Instance.canvas);
    }
    private void randomSpawnPoint()
    {
        var meshRenderer = spawnPointArea.GetComponent<MeshRenderer>();
        Bounds meshBounds = meshRenderer.bounds;
        for(int i =0; i<10; i++)
        {
            Vector3 pointRandom = new Vector3(Random.Range(meshBounds.min.x, meshBounds.max.x),  meshBounds.max.y + 1f, Random.Range(meshBounds.min.z, meshBounds.max.z));
            pointSpawn.Add(pointRandom);
        }
       
    }
}
