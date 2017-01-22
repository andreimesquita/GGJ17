using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using Util;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public delegate void GameOverDelegate();

    public event GameOverDelegate GameOverNotification;

    public EntitiesManager entities;

    public SpawnManager spawnManager;

    public GameHudManager gameHudManager;

    private int deadPlayersCount;

    private void Awake()
    {
        if (Instance)
        {
            if (Instance != this)
                Destroy(this.gameObject);
        }
        else
        {
            Instance = FindObjectOfType<GameManager>();
        }
    }

    private void Start()
    {
        gameHudManager.HideGameOverHud();

        DOVirtual.DelayedCall(1f, ResetGame);
    }
    
    private void GameOver()
    {
        spawnManager.enabled = false;

        if (GameOverNotification != null)
            GameOverNotification();

        gameHudManager.ShowGameOverHud();
    }

    public void ResetGame()
    {
        gameHudManager.HideGameOverHud();

        deadPlayersCount = 0;

        entities.RespawnPlayers();

        DOVirtual.DelayedCall(5, () => { spawnManager.enabled = true; });

        GameManager.Instance.entities.scoreText.text = "0";
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(Constants.SCENE_ID_MAIN_MENU);
    }

    public void ReturnToCharacterSelector()
    {
        SceneManager.LoadScene(Constants.SCENE_ID_CHARACTER_SELECTOR);
    }

    public void NotifyPlayerDead()
    {
        deadPlayersCount++;

        if (deadPlayersCount == 2)
            GameOver();
    }
}