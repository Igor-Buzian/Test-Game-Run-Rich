using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] int moneyCollected = 40;
    [SerializeField] int currentMoneyCountMinus = 0;
    [SerializeField] int currentMoneyCountPlus = 0;
    [SerializeField] private TextMeshProUGUI MoneyCollectedText;
    [SerializeField] private GameObject MoneyCanvas;
    private WaitForSeconds TwoSecond;
    PlayerMovement PlayerMovement;
    [Header("progressBar")]
    public Image progressBar;
    public Animator characterAnimator;
    public string animationTrigger;
    public float fillAmountThreshold = 0f; // ��������� �������� 0f
    Collider characterCollider;
    [Header("ChangeGameobjects")]
    [SerializeField] GameObject[] Player;
    int CustomCount;
    [SerializeField] float[] threshold;
    private bool canvasActive = false;
    public bool exit = true;
    private Quaternion initialRotation;
    private float rotationDuration = 1f; // ������������ �������� � ��������
    private void Start()
    {
        initialRotation =transform.rotation;
        characterCollider = GetComponent<Collider>();
        PlayerMovement = FindAnyObjectByType<PlayerMovement>();
        fillAmountThreshold = threshold[0];
        TwoSecond = new WaitForSeconds(2);
        if (MoneyCollectedText == null)
        {
            gameObject.SetActive(false);
        }
        // ������������� ��������� �������� fillAmountThreshold
        UpdateFillAmountThreshold();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Money"))
        {
            CollectItem("Money", 2);
        }
        else if (other.CompareTag("Alcohol"))
        {
            CollectItem("Alcohol", 20);
        }
        else if (other.CompareTag("Frame"))
        {
            if (other.gameObject.GetComponent<FrameLogic>()?.XLogic == true)
            {
                int allMoney = moneyCollected * other.gameObject.GetComponent<FrameLogic>().MoneyCount;
                CollectItem("XLogic", allMoney);
            }
            else if (other.gameObject.GetComponent<FrameLogic>()?.AlchoholFrame == true)
            {
                CollectItem("AlchoholFrame", other.gameObject.GetComponent<FrameLogic>().MoneyCount);
            }
            else
            {
                CollectItem("MoneyFrame", other.gameObject.GetComponent<FrameLogic>().MoneyCount);
            }

        }
        else
        {
            UnityEngine.Debug.LogWarning("����������� ��� ��������: " + other.name);
        }

        // �������� � ������ �������� ����� ������� �����
        CheckAndPlayAnimation();

        other.gameObject.SetActive(false);
    }


    private void CollectItem(string itemType, int count)
    {
        // ����������� ��� ��������� ���� � ����������� �� ���� ��������
        if (itemType == "Money" || itemType == "MoneyFrame" || itemType == "XLogic")
        {
            currentMoneyCountMinus = 0;
            currentMoneyCountPlus += count;
            moneyCollected += count;
            MoneyCollectedText.color = Color.green;
            MoneyCollectedText.text = $"+ {currentMoneyCountPlus} $";
        }
        else if (itemType == "Alcohol" || itemType == "AlchoholFrame")
        {
            currentMoneyCountPlus = 0;
            currentMoneyCountMinus += count;
            moneyCollected -= count;
            MoneyCollectedText.color = Color.red;
            MoneyCollectedText.text = $"- {currentMoneyCountMinus} $";
        }

        // ��������� ����� ����� ������� �����
        UpdateFillAmountThreshold();

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

    // ������� ��� �������� � ������� ��������
    void CheckAndPlayAnimation()
    {
        if (exit)
        {
            if (moneyCollected >= threshold[CustomCount])
            {
                if (characterAnimator != null)
                {
                    exit = false;
                    characterAnimator.SetTrigger("custom");
                }
                progressBar.fillAmount = 0f; // ����� �����
                UpdateFillAmountThreshold(); // ��������� ����� ����� ��������
            }
        }
        
        progressBar.fillAmount = (float)moneyCollected / 1000f; // ��������� ����� ���������
    }

    // ������� ��� ���������� fillAmountThreshold
    void UpdateFillAmountThreshold()
    {
        // ����� ���������� ������ ��������� ������ � ����������� �� moneyCollected
        // ������:  ����� ������������� � ������� 20 ���������� ��������
        fillAmountThreshold = (float)moneyCollected / 1000f; // ������: ����� ����� �������� �� 100
                                                            //fillAmountThreshold = Mathf.Clamp01((float)moneyCollected / 20f); // ������: ����� ������������� � ������� 20 ��������, �� �� ��������� 1
    }
    public void StartMethod()
    {
        PlayerMovement.enabled = false;
        StartCoroutine(RotateCharacterCoroutine());
        StartCoroutine(ChangeCustomCoroutine());
    }

    private IEnumerator RotateCharacterCoroutine()
    {
        float elapsedTime = 0f;
        Quaternion targetRotation = Quaternion.Euler(0f, 360f, 0f) * initialRotation;

        Debug.Log("�������� �������� ���������");

        while (elapsedTime < rotationDuration)
        {
            float t = elapsedTime / rotationDuration;
            transform.rotation = Quaternion.Lerp(initialRotation, targetRotation, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetRotation;
        Debug.Log("�������� ���������");
    }
    private IEnumerator ChangeCustomCoroutine() 
    {
        yield return TwoSecond;
        PlayerMovement.enabled = true;
        //characterCollider.enabled = true;
        CustomCount++;
        fillAmountThreshold = threshold[CustomCount];
        Player[CustomCount - 1].SetActive(false);
        Player[CustomCount].SetActive(true);
        exit = true;
        characterAnimator.SetTrigger("Exit");
    }


    public void ChangeCustom()
    {
      

    }

    public int GetCollectedAmount(string itemType)
    {
        if (itemType == "Money")
        {
            return moneyCollected;
        }
        else
        {
            UnityEngine.Debug.LogError("����������� ��� ��������!");
            return 0;
        }
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("MoneyCollected", moneyCollected);
        PlayerPrefs.Save();
        UnityEngine.Debug.Log("������ ���������!");
    }

    public void LoadData()
    {
        moneyCollected = PlayerPrefs.GetInt("MoneyCollected", 0);
    }
}