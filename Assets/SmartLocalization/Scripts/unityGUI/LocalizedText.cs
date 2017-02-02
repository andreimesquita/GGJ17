using SmartLocalization;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.SmartLocalization.Scripts.unityGUI
{
    [RequireComponent(typeof(Text))]
    public class LocalizedText : MonoBehaviour
    {
        public string localizedKey = "INSERT_KEY_HERE";
        Text textObject;

        void Start()
        {
            textObject = this.GetComponent<Text>();

            //Subscribe to the change language event
            LanguageManager languageManager = LanguageManager.Instance;
            languageManager.OnChangeLanguage += OnChangeLanguage;

            //Run the method one first time
            OnChangeLanguage(languageManager);
        }

        void OnDestroy()
        {
            if (LanguageManager.HasInstance)
            {
                LanguageManager.Instance.OnChangeLanguage -= OnChangeLanguage;
            }
        }

        void OnChangeLanguage(LanguageManager languageManager)
        {
            textObject.text = LanguageManager.Instance.GetTextValue(localizedKey);
        }
    }
}