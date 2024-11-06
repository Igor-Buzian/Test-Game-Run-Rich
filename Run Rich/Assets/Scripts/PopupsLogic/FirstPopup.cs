using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPopup : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0f;
    }

    public void CloseButton()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
}
