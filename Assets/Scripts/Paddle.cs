using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField] private float speed = 100f;

    private void Update() {
        float moveInput = InputManager.Instance.MoveInput;

        Vector3 pos = transform.position;
        pos.y += speed * moveInput * Time.deltaTime;

        pos.y = Mathf.Clamp(pos.y, -4f, 4f);

        transform.position = Vector3.Lerp(transform.position, pos, 1f);

    #if UNITY_ANDROID || UNITY_IOS
        Vector2 touch = InputManager.Instance.TouchPosition;

        if (touch != Vector2.zero)
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(touch);
            transform.position = new Vector3(transform.position.x, worldPos.y, 0f);
        }
    #endif

    }
}
