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

    private void Start()
    {
        PlayerMovement = FindAnyObjectByType<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            ui.SetActive(true);
            Time.timeScale = 0;
            Money.text = FindAnyObjectByType<MoneyManager>().moneyCollected.ToString();
            FindAnyObjectByType<MoneyManager>().SaveData();
           
        }
    }

    public void WinButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
