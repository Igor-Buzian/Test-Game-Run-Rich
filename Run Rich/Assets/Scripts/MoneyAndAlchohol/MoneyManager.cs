using UnityEngine;
using TMPro;
using System.Collections;

public class MoneyManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI MoneyCollectedText;
    [SerializeField] GameObject MoneyCanvas;
    TextMeshProUGUI FullMoneyInfo;
    int FullMoney;
    public int moneyCollected;
    private bool canvasActive;
    int currentMoneyCountPlus;
    int currentMoneyCountMinus;

    WaitForSeconds TwoSecond;

    private void Start()
    {
        FullMoneyInfo = GetComponent<TextMeshProUGUI>();
        TwoSecond = new WaitForSeconds(2);
    }

    public void CollectMoney(int amount)
    {
        moneyCollected += amount;
        currentMoneyCountPlus += amount;
        currentMoneyCountMinus = 0;
        UpdateMoneyText(currentMoneyCountPlus, true);
        if (!canvasActive)
        {
            StartCoroutine(CollectDelay());
        }
        else
        {
            StopCoroutine("CollectDelay");
            StartCoroutine(CollectDelay());
        }
    }
    public void Frame(int amount, bool Xlogic = false)
    {
        currentMoneyCountMinus = 0;
        moneyCollected *= amount;
        UpdateMoneyText(moneyCollected, true);
        if (!canvasActive)
        {
            StartCoroutine(CollectDelay());
        }
        else
        {
            StopCoroutine("CollectDelay");
            StartCoroutine(CollectDelay());
        }
    }

    public void SpendMoney(int amount)
    {
        FullMoney -= amount;
        currentMoneyCountPlus =0;
        currentMoneyCountMinus += amount;
        UpdateMoneyText(currentMoneyCountMinus, false);

        if (FullMoney < 0)
        {
            FullMoney = 40; // Reset to initial value
            FindAnyObjectByType<LoseLogic>().OpenUI();
            return;
        }

        if (!canvasActive)
        {
            StartCoroutine(CollectDelay());
        }
        else
        {
            StopCoroutine("CollectDelay");
            StartCoroutine(CollectDelay());
        }
    }
    IEnumerator CollectDelay()
    {
        canvasActive = true;
        MoneyCanvas.SetActive(true);
        yield return TwoSecond;
        currentMoneyCountPlus = 0;
        currentMoneyCountMinus = 0;
        MoneyCanvas.SetActive(false);
        canvasActive = false;
    }
    public void WaitCollectDelay()
    {
        while (canvasActive)
        {
            return;
        }
        Time.timeScale = 0;
    }

    private void UpdateMoneyText(int moneyCollected, bool IncreaseMoneyText)
    {
        if(IncreaseMoneyText)
        {
            MoneyCollectedText.color = Color.green;
            MoneyCollectedText.text = $"{moneyCollected} $";
        }
        else
        {
            MoneyCollectedText.color = Color.red;
            MoneyCollectedText.text = $"- {moneyCollected} $";
        }
       
    }

    public int GetCollectedAmount()
    {
        int GetCollectedAmount = FullMoney + moneyCollected;
        return GetCollectedAmount;
    }

    public void SaveData()
    {
        FullMoney += moneyCollected;
        moneyCollected = 0;
        PlayerPrefs.SetInt("FullMoney", FullMoney);
        PlayerPrefs.Save();
        Debug.Log("Данные сохранены!");
    }

    public void LoadData()
    {
        if (PlayerPrefs.HasKey("FullMoney"))
        {
            moneyCollected = 0;
        }
        FullMoney = PlayerPrefs.GetInt("FullMoney", 40);
        FullMoneyInfo.text = $"{FullMoney}";
    }

    public int FirstAmountMoney()
    {
        return PlayerPrefs.GetInt("FullMoney", 40);
    }
}