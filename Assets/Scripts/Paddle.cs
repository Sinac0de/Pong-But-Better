using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField] private float speed = 100f;

    private void Update() {
        float moveInput = InputManager.Instance.MoveInput;

        Vector3 pos = transform.position;
        pos.y += speed * moveInput * Time.deltaTime;

        pos.y = Mathf.Clamp(pos.y, -4f, 4f);

        transform.position = pos;
    }
}
