using System;
using SmartLocalization;
using UnityEngine;

namespace Assets.Scripts.Util
{
    public class LanguageSwitcher : MonoBehaviour
    {
        public enum Language
        {
            Portuguese,
            English
        }

        private static class LanguageHelper
        {
            public static string ParseLanguage(Language lang)
            {
                switch (lang)
                {
                    case Language.Portuguese:
                        return "pt-BR";
                        break;
                    case Language.English:
                        return "en";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("lang", lang, null);
                }
            }
        }

        public void SwitchLanguage(Language newLanguage)
        {
            string languageString = LanguageHelper.ParseLanguage(newLanguage);

            LanguageManager.Instance.defaultLanguage = languageString;

            LanguageManager.Instance.ChangeLanguage(languageString);
        }

        private void Start()
        {

            LanguageManager.SetDontDestroyOnLoad();

#if ANDROID
            Destroy(this.gameObject);
#endif
        }

        private void OnGUI()
        {
            if (GUILayout.Button("English"))
                SwitchLanguage(Language.English);

            if (GUILayout.Button("Português"))
                SwitchLanguage(Language.Portuguese);
        }
    }
}
