using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField] private float initialSpeed = 10.0f;
    [SerializeField] private float speedIncrease = 0.5f;
    [SerializeField] private float impactScaleMultiplier = 1.5f;

    private Rigidbody2D rb;
    private float currentSpeed;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        Launch();
    }


    public void Launch() {

        currentSpeed = initialSpeed;

        float direction = Random.value > 0.5 ? 1f : -1f;
        float angle = Random.Range(-0.5f, 0.5f);

        Vector2 velocity = new Vector2(direction, angle).normalized;

        rb.linearVelocity = velocity * currentSpeed;
    }


    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Paddle")) {
            currentSpeed += speedIncrease;
            rb.linearVelocity = rb.linearVelocity.normalized * currentSpeed;
        }

        // impact on hit
        transform.localScale *= impactScaleMultiplier;
        Invoke(nameof(ResetScale), 0.05f);
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.CompareTag("RightGoal")) {
            ScoreManager.Instance.PlayerScored();
        }

        if (collision.CompareTag("LeftGoal")) {
            ScoreManager.Instance.AiScored();
        }
    }


    public void ResetBall() {
        //stop the ball (zero velocity)
        Stop();
        ResetPosition();
    }

    public void Stop() {
        rb.linearVelocity = Vector2.zero;
    }

    private void ResetScale() {
        transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
    }

    private void ResetPosition() {
        transform.position = Vector2.zero;
    }
}
