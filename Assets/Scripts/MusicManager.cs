using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;

    public AudioClip scene0to2And6Clip;
    public AudioClip scene3Clip;
    public AudioClip scene4Clip;
    public AudioClip scene5Clip;
    public AudioClip scene6Clip;


    private AudioSource audioSource;

    private void Awake()
    {
        // Verificar si ya existe una instancia
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Reproducir la canción correcta según la escena
        switch (scene.buildIndex)
        {
            case 0:
            case 1:
            case 2:
            case 4:
            case 6:
            case 9:
                if (audioSource.clip != scene0to2And6Clip)
                {
                    audioSource.clip = scene0to2And6Clip;
                    audioSource.Play();
                }
                break;
            case 3:
                if (audioSource.clip != scene3Clip)
                {
                    audioSource.clip = scene3Clip;
                    audioSource.Play();
                }
                break;
            case 5:
                if (audioSource.clip != scene4Clip)
                {
                    audioSource.clip = scene4Clip;
                    audioSource.Play();
                }
                break;
            case 7:
                if (audioSource.clip != scene5Clip)
                {
                    audioSource.clip = scene5Clip;
                    audioSource.Play();
                }
                break;
            case 8:
            if (audioSource.clip != scene6Clip)
            {
                audioSource.clip = scene6Clip;
                audioSource.Play();
            }
            break;
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
