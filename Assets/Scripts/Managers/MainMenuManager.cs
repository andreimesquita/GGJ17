using Assets.Scripts.So;
using Assets.Scripts.Util;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Managers
{
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

        public void OnLanguagePressed()
        {
            //Delete the key into PlayerPrefs
            PlayerPrefs.DeleteKey(Constants.CURRENT_LANGUAGE_CODE_KEY);

            //Return to the LanguageSelection' scene
            SceneManager.LoadScene(Constants.SCENE_ID_LANGUAGE_SELECTION);
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
}