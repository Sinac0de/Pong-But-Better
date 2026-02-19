using UnityEngine;

public class SoundManager : MonoBehaviour {
    public static SoundManager Instance;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip paddleHit;
    [SerializeField] private AudioClip wallHit;
    [SerializeField] private AudioClip scoreSound;
    [SerializeField] private AudioClip powerUpSound;
    [SerializeField] private AudioClip winSound;

    private AudioSource audioSource;

    private void Awake() {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPaddleHit() => audioSource.PlayOneShot(paddleHit);
    public void PlayWallHit() => audioSource.PlayOneShot(wallHit);
    public void PlayScore() => audioSource.PlayOneShot(scoreSound);
    public void PlayPowerUp() => audioSource.PlayOneShot(powerUpSound);
    public void PlayWin() => audioSource.PlayOneShot(winSound);
}
