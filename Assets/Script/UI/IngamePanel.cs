using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IngamePanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI aliveTxt;
    [SerializeField] private GameObject settingPanel;
    private void Update()
    {
        aliveTxt.text = "Alive: " + LevelManager.Instance.numberBot;
    }
    public void ClickSetTing()
    {
        gameObject.SetActive(false);
        settingPanel.SetActive(true);
    }
}
