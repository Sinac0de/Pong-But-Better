using System;
using System.Collections;
using UnityEngine;

public enum GameState {
    Start,
    Playing,
    PointScored,
    GameOver
}

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }

    public event Action<String> OnGameOver;
    [Header("References")]
    [SerializeField] private Ball ball;
    [SerializeField] private Camera mainCamera;

    [Header("Game Settings")]
    [SerializeField] private int scoreToWin = 5;

    private Vector3 originalCamPos;
    private GameState currentState;


    private void Awake() {
        // Singleton pattern
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        // save the initial camera position
        originalCamPos = mainCamera.transform.position;

        // start the game
        currentState = GameState.Start;
        StartGame();

        // subscribe to the Score events
        ScoreManager.Instance.OnPlayerScored += () => StartCoroutine(HandlePoint(true));
        ScoreManager.Instance.OnAIScored += () => StartCoroutine(HandlePoint(false));
    }

    private void Update() {
        switch (currentState) {
            case GameState.Start:
                break;
            case GameState.Playing:
                Time.timeScale = 1f; // Ensure the game is running at normal speed
                break;
            case GameState.PointScored:
                // Wait for the point scored coroutine to finish
                break;
            case GameState.GameOver:
                Time.timeScale = 0f; // Pause the game
                break;
        }
    }

    #region Game Flow

    private void StartGame() {
        currentState = GameState.Playing;
        ball.Launch();
    }


    private IEnumerator HandlePoint(bool playerScored) {
        currentState = GameState.PointScored;

        // Stop ball
        ball.Stop();

        // Camera Shake
        yield return StartCoroutine(Shake(0.1f, 0.5f));

        // Check Win Condition
        if (ScoreManager.Instance.PlayerScore >= scoreToWin) {
            currentState = GameState.GameOver;
            OnGameOver?.Invoke("Player Wins!");
        } else if (ScoreManager.Instance.AIScore >= scoreToWin) {
            currentState = GameState.GameOver;
            OnGameOver?.Invoke("AI Wins!");
        } else {
            ball.ResetBall();

            // Wait a moment, then continue
            yield return new WaitForSeconds(1f);
            currentState = GameState.Playing;
            ball.Launch();
        }
    }

    public void ResetGame() {
        ScoreManager.Instance.ResetScores();

        ball.ResetBall();
        currentState = GameState.Playing;
        ball.Launch();
    }

    #endregion

    #region Camera Shake

    public IEnumerator Shake(float duration, float magnitude) {
        float elapsed = 0f;

        while (elapsed < duration) {
            float percentComplete = elapsed / duration;
            float damper = 1f - percentComplete;

            float x = UnityEngine.Random.Range(-1f, 1f) * magnitude * damper;
            float y = UnityEngine.Random.Range(-1f, 1f) * magnitude * damper;

            mainCamera.transform.position = originalCamPos + new Vector3(x, y, 0);

            elapsed += Time.deltaTime;
            yield return null;
        }

        mainCamera.transform.position = originalCamPos;
    }

    #endregion

    public GameState GetCurrentGameState() {
        return currentState;
    }
}
