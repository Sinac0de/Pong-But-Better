
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] private TextMeshProUGUI playerScoreText;
    [SerializeField] private TextMeshProUGUI aiScoreText;

    private int playerScore;
    private int aiScore;

    private void Awake() {
        if(Instance != null) {
            Destroy(Instance);
        }
        Instance = this;
    }

    public void PlayerScored() {
        playerScore++;
        UpdateUI();
    }

    public void AiScored() {
        aiScore++;
        UpdateUI();
    }

    private void UpdateUI() {
        playerScoreText.text = playerScore.ToString();
        aiScoreText.text = aiScore.ToString();
    }
}
