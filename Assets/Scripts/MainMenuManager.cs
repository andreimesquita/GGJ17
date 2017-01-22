using So;
using UnityEngine;
using UnityEngine.SceneManagement;
using Util;

public class MainMenuManager : MonoBehaviour
{
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
        //TODO: shows up the achievements' list
    }

    public void OnExitPressed()
    {
        audioSource.PlayOneShot(audioListSo.ClickClip);
        Application.Quit();
    }
}