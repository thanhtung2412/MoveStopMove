using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public Bot botPrefabs;
    public Player player;
    private int currentLevelPlayer;
    public int numberBot = 100;
    [SerializeField] private GameObject pointPlayer;
    public List<Transform> pointDespawnBot = new List<Transform>();
    private List<Bot> bots = new List<Bot>();
    public bool isCanDespawn = false;
    private float timeCanDespawn = 0;
    [SerializeField] private CameraFollow cameraFollow;
    private void Awake()
    {
        OnStartGame();
    }

    void Update()
    {
        currentLevelPlayer = player.currentLevel;
        if(Time.time > timeCanDespawn && numberBot > 0 && isCanDespawn) 
        { 
            OnDespawmBot();
            timeCanDespawn += 50f;
        }     
    }
   
    public void OnDespawmBot()
    {
        int randPointDespawn = Random.Range(0, pointDespawnBot.Count);
        if(currentLevelPlayer <= 5)
        {
            int randLevelBot = Random.Range(0, 4);
            Bot bot = SimplePool.Spawn<Bot>(botPrefabs, pointDespawnBot[randPointDespawn].position, pointDespawnBot[randPointDespawn].rotation);
            bot.currentLevel = randLevelBot;
            bots.Add(bot);
            numberBot--;
        }
        else
        {
            int randLevelBot = Random.Range(currentLevelPlayer - 3, currentLevelPlayer + 3);
            Bot bot = SimplePool.Spawn<Bot>(botPrefabs, pointDespawnBot[randPointDespawn].position, pointDespawnBot[randPointDespawn].rotation);
            bot.currentLevel = randLevelBot;
            bots.Add(bot);
            numberBot--;
        }
    }
    public void OnStartGame()
    {
        player.ChangeWeapon();
        if(Pref.EquipsType == 1)
        {
            player.ChangeHat();
        }else if(Pref.EquipsType == 2)
        {
            player.ChangePant();
        }else if (Pref.EquipsType == 3)
        {
            player.ChangeShield();
        }
        else
        {
            player.ChangeSetFull();
        }
    }
    public void OnPlayGame()       
    {
        cameraFollow.isCanFollowTarget = true;       
    }
    public void OnReset()
    {
        for (int i = 0; i < bots.Count; i++)
        {
            SimplePool.Despawn(bots[i].targetIndicator);
            SimplePool.Despawn(bots[i]);
        }
        
        bots.Clear();
        isCanDespawn = false;
        player.isCanMove = false;
        cameraFollow.isCanFollowTarget = false;
        cameraFollow.transform.position = new Vector3(0, 11f, -20f);
        cameraFollow.transform.rotation = Quaternion.Euler(new Vector3(38, 0, 0));
        player.transform.position = pointPlayer.transform.position;
    }
    public void OnHome()
    {
        OnReset();
        UIManager.Instance.coinPanel.SetActive(true);
        UIManager.Instance.shopPanel.SetActive(true);
    }
      
}
