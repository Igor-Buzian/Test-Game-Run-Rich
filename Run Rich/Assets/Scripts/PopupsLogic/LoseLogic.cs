using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseLogic : MonoBehaviour
{
    public Button Lose;
    [SerializeField] GameObject player;
    public Vector3 Position;
    [SerializeField] GameObject UI;
    public int rotation;
    public void OpenUI()
    {
        UI.SetActive(true);
        Time.timeScale = 0f;

    }
    public void ReturnButton()
    {
        Time.timeScale = 1f;
        if(Position != Vector3.zero) 
        { 
            player.transform.position = Position;
            player.transform.rotation = Quaternion.Euler(0, rotation, 0);
            UI.SetActive(false);
        } 
        else
        {
            SceneManager.LoadScene(0);
        }
        

    }
}
