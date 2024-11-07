using ButchersGames;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishZone : MonoBehaviour
{
    [Header("Win UI")]
    [SerializeField] GameObject ui;
    [SerializeField] TextMeshProUGUI Money;
    int currentMoney;

    PlayerMovement PlayerMovement;
    FirstPopup FirstPopup;
    MoneyManager MoneyManager;

    private void Start()
    {
        PlayerMovement = FindAnyObjectByType<PlayerMovement>();
        FirstPopup = FindAnyObjectByType<FirstPopup>();
        MoneyManager = FindAnyObjectByType<MoneyManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            ui.SetActive(true);
            Time.timeScale = 0;
            Money.text = MoneyManager.moneyCollected.ToString();
            MoneyManager.SaveData();
           
        }
    }

    public void WinButton()
    {
        MoneyManager.LoadData();
        PlayerMovement.BackToFirstPosition();
        FirstPopup.OpenPopup();
        LevelManager.Default.NextLevel();
    }
}
