using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Ball ball;

    private void Start() {
        ball.Launch();
    }
}
