using UnityEngine;

public class PaddleAI : MonoBehaviour {
    [SerializeField] private float easySpeed = 2f;
    [SerializeField] private float mediumSpeed = 6f;
    [SerializeField] private float hardSpeed = 8f;
    [SerializeField] private float returnToCenterSpeed = 4f;

    [SerializeField] private Rigidbody2D ballRb;

    private float currentSpeed;
    private float originalSpeed;

    private void Start() {

        switch (GameSettings.SelectedDifficulty) {
            case Difficulty.Easy:
                currentSpeed = easySpeed;
                break;
            case Difficulty.Medium:
                currentSpeed = mediumSpeed;
                break;
            case Difficulty.Hard:
                currentSpeed = hardSpeed;
                break;
        }

        originalSpeed = currentSpeed;
    }

    private void Update() {


        float targetY = ballRb.transform.position.y;

        // hard mode prediction
        if (GameSettings.SelectedDifficulty == Difficulty.Hard) {
            targetY += ballRb.linearVelocityY * 0.2f;
        }

        Vector3 pos = transform.position;

        if (ballRb.linearVelocityX < 0) {
            //The ball is going left (towards the player)
            pos.y = Mathf.MoveTowards(pos.y, 0, returnToCenterSpeed * Time.deltaTime);
        } else {
            //The ball is going right (towards the ai)
            pos.y = Mathf.MoveTowards(pos.y, targetY, currentSpeed * Time.deltaTime);
        }

        pos.y = Mathf.Clamp(pos.y, -4f, 4f);




        transform.position = pos;

    }

    public void SetTemporarySpeedMultiplier(float multiplier) {
        currentSpeed *= multiplier;
    }

    public void ResetSpeed() {
        currentSpeed = originalSpeed;
    }



}
