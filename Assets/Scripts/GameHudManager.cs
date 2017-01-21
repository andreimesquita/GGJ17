using UnityEngine;
using UnityEngine.UI;

public class GameHudManager : MonoBehaviour
{
    public RectTransform gameOverPanel;

    public Text points;

    public void HideGameOverHud()
    {
        gameOverPanel.gameObject.SetActive(false);
    }

    public void ShowGameOverHud()
    {
        gameOverPanel.gameObject.SetActive(true);
    }
}
