using Assets.Scripts.Util;
using SmartLocalization;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Managers
{
    public class LanguageSelectionManager : LanguageSwitcher
    {
        [SerializeField]
        private bool resetLanguage;

        public GameObject rootPanel;

        protected override void Start()
        {
            if (resetLanguage)
            {
                PlayerPrefs.DeleteKey(Constants.CURRENT_LANGUAGE_CODE_KEY);
            }

            LanguageManager.SetDontDestroyOnLoad();

            if (PlayerPrefs.HasKey(Constants.CURRENT_LANGUAGE_CODE_KEY))
            {
                rootPanel.SetActive(false);

                string currentLanguageCode = PlayerPrefs.GetString(Constants.CURRENT_LANGUAGE_CODE_KEY);

                LanguageManager.Instance.ChangeLanguage(currentLanguageCode);

                SceneManager.LoadScene(Constants.SCENE_ID_MAIN_MENU);
            }
        }

        public void SelectLanguage(string languageName)
        {
            switch (languageName)
            {
                case "portuguese":
                    SwitchLanguage(Language.Portuguese);
                    break;
                case "english":
                    SwitchLanguage(Language.English);
                    break;
                default:
                    Debug.LogErrorFormat("{0} was not recognized!", languageName);
                    break;
            }
        }

        protected override void OnLanguageSwitched(string languageCode)
        {
            LanguageManager.Instance.ChangeLanguage(languageCode);

            //Save languageCode in PlayerPrefs for later usage
            PlayerPrefs.SetString(Constants.CURRENT_LANGUAGE_CODE_KEY, languageCode);

            SceneManager.LoadScene(Constants.SCENE_ID_MAIN_MENU);
        }
    }
}
