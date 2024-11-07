using ButchersGames;
using UnityEngine;

public class GameStarter : MonoBehaviour
{

    private void Start()
    {
        LevelManager.Default.Init();
        LevelManager.Default.StartLevel();
    }
}