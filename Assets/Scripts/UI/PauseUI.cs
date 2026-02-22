using UnityEngine;

public class PauseUI : MonoBehaviour
{
    private void Start() {
        Hide();

        InputManager.Instance.OnPauseAction += InputManager_OnPauseAction;
    }

    private void InputManager_OnPauseAction() {
        if (GameManager.Instance.GetCurrentGameState() == GameState.Paused) {
            ResumeGame();
        } else if (GameManager.Instance.GetCurrentGameState() == GameState.Playing) {
            PauseGame();
        }
    }

    public void PauseGame() {
        Show();
        GameManager.Instance.PauseGame();
    }

    public void ResumeGame() {
        Hide();
        GameManager.Instance.ResumeGame();
    }

    private void Show() {
        gameObject.SetActive(true);
    }

    private void Hide() {
        gameObject.SetActive(false);
    }
}
