using System.Collections.Generic;
using Achievements;
using DG.Tweening;
using So;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Util;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioListSo audioListSo;
    [SerializeField] private MissionsSo missionsSo;
    [SerializeField] private NotificationMsgsPanel notificationMsgsPanel;

    public static GameManager Instance { get; private set; }

    public delegate void GameOverDelegate();

    public event GameOverDelegate GameOverNotification;

    public EntitiesManager entities;

    public SpawnManager spawnManager;

    public GameHudManager gameHudManager;

    private int deadPlayersCount;

    private List<Mission> missions = new List<Mission>();
    private float initialPlayTime;

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
        
        InvokeRepeating("ShowNotificationMsgs", 15.0f, 15.0f);

        initialPlayTime = Time.time;
        missionsSo.ResetGameValues();
    }
    
    private void GameOver()
    {
        spawnManager.enabled = false;

        if (GameOverNotification != null)
            GameOverNotification();

        gameHudManager.ShowGameOverHud();
    }

    public void OnResetGamePress()
    {
        AudioSourceManager.Instance.audioSource.PlayOneShot(audioListSo.ClickClip);
        ResetGame();
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
        AudioSourceManager.Instance.audioSource.PlayOneShot(audioListSo.ClickClip);
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

    private void ShowNotificationMsgs()
    {
        missionsSo.Persist(MissionType.CURRENT_SPACESHIPS_PLAYING, 2-deadPlayersCount);
        missionsSo.Increment(MissionType.TOTAL_GAME_PLAYED, Time.time - initialPlayTime);
        missionsSo.Persist(MissionType.TOTAL_GAME_PLAYED_IN_CURRENT_GAME, Time.time - initialPlayTime);

        Mission mission;
        if (missionsSo.FindCompletedMissions(out mission))
        {
            this.notificationMsgsPanel.ShowMessage(mission.PresentationText);
        }
    }
}