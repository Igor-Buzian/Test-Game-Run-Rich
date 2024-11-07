using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Image progressBar;
    short maxMassiveAmount = 2000;
    /*private void Awake()
    {
        progressBar = GetComponent<Image>();
    }*/
    public void UpdateProgress(float currentAmount, float maxAmount, System.Action onComplete = null)
    {
        if (maxAmount < maxMassiveAmount) 
        {
            float fillAmount = currentAmount / maxAmount;
            progressBar.fillAmount = fillAmount;

            if (fillAmount >= 1f)
            {
                // Если прогресс достиг 100%, вызываем анимацию и сбрасываем
                onComplete?.Invoke();
                ResetProgress();
            }
        }
        else
        {
            progressBar.fillAmount = 1;
        }


    }

    private void ResetProgress()
    {
        progressBar.fillAmount = 0f; // Сброс шкалы
    }
}