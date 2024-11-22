using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public Button button;
    public AudioClip buttonClickClip;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (button != null && buttonClickClip != null)
        {
            button.onClick.AddListener(PlayButtonClickSound);
        }
    }

    private void PlayButtonClickSound()
    {
        audioSource.PlayOneShot(buttonClickClip);
    }
}
