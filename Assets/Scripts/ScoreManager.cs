
using System;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public event Action OnPlayerScored;
    public event Action OnAIScored;

    [SerializeField] private TextMeshProUGUI playerScoreText;
    [SerializeField] private TextMeshProUGUI aiScoreText;

    public int PlayerScore => playerScore;
    public int AIScore => aiScore;

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
        OnPlayerScored.Invoke();
        UpdateUI();
    }

    public void AiScored() {
        aiScore++;
        OnAIScored.Invoke();
        UpdateUI();
    }

    private void UpdateUI() {
        playerScoreText.text = playerScore.ToString();
        aiScoreText.text = aiScore.ToString();
    }

    public void ResetScores(){
        aiScore = 0;
        playerScore = 0;
        UpdateUI();
    }
}
