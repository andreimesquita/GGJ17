using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceManager : MonoBehaviour
{
    public static AudioSourceManager Instance;
    public AudioSource audioSource;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this.gameObject);
        if (Instance == null) Instance = this;

        DontDestroyOnLoad(this.gameObject);

        audioSource = this.GetComponent<AudioSource>();
    }
}
