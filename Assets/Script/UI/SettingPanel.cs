using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPanel : MonoBehaviour
{
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject coinPanel;
    [SerializeField] private GameObject inGamePanel;
    public void ClickHome()
    {
        LevelManager.Instance.OnHome();              
        gameObject.SetActive(false);
    }
    public void ClickContinue()
    {      
        inGamePanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
