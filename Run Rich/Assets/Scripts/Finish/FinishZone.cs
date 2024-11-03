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

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            Money.text = FindAnyObjectByType<ItemCollector>().moneyCollected.ToString();
            FindAnyObjectByType<ItemCollector>().SaveData();
            Time.timeScale = 0;
        }
    }

    public void WinButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
