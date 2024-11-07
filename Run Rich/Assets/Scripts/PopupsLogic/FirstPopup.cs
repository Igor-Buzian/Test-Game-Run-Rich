using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPopup : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0f;
    }
    public void OpenPopup()
    {
        gameObject.SetActive(true);
        StartCoroutine(DelayForOpenPopup());
    }
    IEnumerator DelayForOpenPopup()
    {
        yield return new WaitForSeconds(.5f);
        Time.timeScale = 0f;
    }

    public void CloseButton()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
}
