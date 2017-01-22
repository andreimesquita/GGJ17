using UnityEngine;
using UnityEngine.SceneManagement;
using Util;

public class MainMenuManager : MonoBehaviour
{
    public void OnPlayPressed()
    {
        SceneManager.LoadScene(Constants.SCENE_ID_CHARACTER_SELECTOR);
    }

    public void OnAchievementsPressed()
    {
        //TODO: shows up the achievements' list
    }

    public void OnExitPressed()
    {
        Application.Quit();
    }
}