
using UnityEngine;

public enum PowerUpType {
    BigPaddle,
    SlowAI,
    FastBall
}


public class PowerUp : MonoBehaviour {


    [SerializeField] private PowerUpType powerUpType;
    [SerializeField] private float powerUpDuration = 5f;


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Ball")) {
            GameManager.Instance.ActivatePowerUp(powerUpType, powerUpDuration);
            SoundManager.Instance.PlayPowerUp();
            Destroy(gameObject);
        }

    }
}
