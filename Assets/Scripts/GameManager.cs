using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

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

        gameHudManager.ShowGameOverHud();
    }

    public void ResetGame()
    {
        gameHudManager.HideGameOverHud();

        deadPlayersCount = 0;

        entities.RespawnPlayers();

        DOVirtual.DelayedCall(5, () => { spawnManager.enabled = true; });
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void NotifyPlayerDead()
    {
        deadPlayersCount++;

        if (deadPlayersCount == 2)
            GameOver();
    }
}