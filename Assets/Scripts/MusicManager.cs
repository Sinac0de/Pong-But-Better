using UnityEngine;

public class MusicManager : MonoBehaviour {
    public static MusicManager Instance;

    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private AudioClip gameplayMusic;

    private AudioSource audioSource;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMenuMusic() {
        PlayMusic(menuMusic);
    }

    public void PlayGameplayMusic() {
        PlayMusic(gameplayMusic);
    }

    private void PlayMusic(AudioClip clip) {
        if (audioSource.clip == clip) return;

        audioSource.clip = clip;
        audioSource.loop = true;
        audioSource.Play();
    }
}