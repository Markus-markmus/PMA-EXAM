using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    // Static instance to implement Singleton pattern
    private static MusicManager instance;
    // AudioSource component to play music
    private AudioSource audioSource;
    // Reference to Dialogue component
    private Dialogue dialogue;

    private void Awake()
    {
        // Ensure only one instance of the MusicManager exists
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Set the static instance to the current instance
        instance = this;
        // Prevent the MusicManager from being destroyed when loading a new scene
        DontDestroyOnLoad(gameObject);

        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();
        // Find an active Dialogue component in the scene
        dialogue = FindObjectOfType<Dialogue>();
    }

    private void Start()
    {
        // Initial music settings based on the current scene
        PlayMusicBasedOnScene();
    }

    private void OnEnable()
    {
        // Subscribe to scene loading events
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Unsubscribe from scene loading events
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Adjust music settings when a new scene is loaded
        PlayMusicBasedOnScene();
    }

    private void PlayMusicBasedOnScene()
    {
        // Get the current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Check if the current scene is scene 1 or if dialogue is active
        if (currentSceneIndex == 1 || (dialogue != null && dialogue.isActiveAndEnabled))
        {
            // Lower the volume of the music if in scene 1 or dialogue is active
            audioSource.volume = 0.2f; // Adjust the volume level as needed
        }
        else
        {
            // Reset the volume if neither in scene 1 nor dialogue is active
            audioSource.volume = 0.4f;
        }

        // Check if the music is not already playing
        if (!audioSource.isPlaying)
        {
            // Play music if it's not already playing
            audioSource.Play();
        }
    }
}
