using So;
using UnityEngine;
using UnityEngine.SceneManagement;
using Util;

public class MainMenuManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            OnExitPressed();
    }

    [SerializeField] private AudioListSo audioListSo;
    [SerializeField] private AudioSource audioSource;

    public void OnPlayPressed()
    {
        audioSource.PlayOneShot(audioListSo.ClickClip);
        SceneManager.LoadScene(Constants.SCENE_ID_CHARACTER_SELECTOR);
    }

    public void OnAchievementsPressed()
    {
        audioSource.PlayOneShot(audioListSo.ClickClip);
        
        //shows up the achievements' list
        SceneManager.LoadScene(Constants.SCENE_ID_ACHIEVEMENTS);
    }

    public void OnExitPressed()
    {
        audioSource.PlayOneShot(audioListSo.ClickClip);
        Application.Quit();
    }
}