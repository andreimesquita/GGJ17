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
        points.text = GameManager.Instance.entities.scoreText.text;
        gameOverPanel.gameObject.SetActive(true);
    }
}
