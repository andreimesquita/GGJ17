using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public EntitiesManager entities;

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
}