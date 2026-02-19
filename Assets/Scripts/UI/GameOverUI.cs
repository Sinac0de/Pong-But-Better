using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI gameOverText;


    private void Start() {
        Hide();
        GameManager.Instance.OnGameOver += GameManager_OnGameOver;
    }

    private void GameManager_OnGameOver(string winText) {
        gameOverText.text = winText;
        Show();
    }

    private void Hide() {
        gameOverPanel.SetActive(false);
    }

    private void Show() {
        gameOverPanel.SetActive(true);
    }
}
