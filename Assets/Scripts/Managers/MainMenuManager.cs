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

    public void OnPlayPressed()
    {
        AudioSourceManager.Instance.audioSource.PlayOneShot(audioListSo.ClickClip);
        SceneManager.LoadScene(Constants.SCENE_ID_CHARACTER_SELECTOR);
    }

    public void OnAchievementsPressed()
    {
        AudioSourceManager.Instance.audioSource.PlayOneShot(audioListSo.ClickClip);
        //shows up the achievements' list
        SceneManager.LoadScene(Constants.SCENE_ID_ACHIEVEMENTS);
    }

    public void OnCreditsPressed()
    {
        SceneManager.LoadScene(Constants.SCENE_ID_CREDITS);
    }

    public void OnExitPressed()
    {
        AudioSourceManager.Instance.audioSource.PlayOneShot(audioListSo.ClickClip);
        Application.Quit();
    }
}