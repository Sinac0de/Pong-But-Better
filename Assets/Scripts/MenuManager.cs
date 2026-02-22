using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public void StartGameEasy() {
        GameSettings.SelectedDifficulty = Difficulty.Easy;
        SceneManager.LoadScene("GameScene");
    }

    public void StartGameMedium() {
        GameSettings.SelectedDifficulty = Difficulty.Medium;
        SceneManager.LoadScene("GameScene");
    }

    public void StartGameHard() {
        GameSettings.SelectedDifficulty = Difficulty.Hard;
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame() {
        Application.Quit();
    }
}