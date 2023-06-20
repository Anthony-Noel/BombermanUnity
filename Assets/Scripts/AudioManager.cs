using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager _instance { get; private set; }

    [SerializeField] private AudioSource _audioSource;


    private void Awake() 
    {
        _instance = this;
    }

    public void PlaySFX(AudioClip clipToPlay)
    {
        _audioSource.PlayOneShot(clipToPlay);
    }

    public void StopSFX(AudioClip clipToPlay)
    {
        _audioSource.Stop();
    }
}
