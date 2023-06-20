using UnityEngine;

public class SoundTrackManager : MonoBehaviour
{
    public static SoundTrackManager _instanceST { get; private set; }

    [SerializeField] private AudioSource _audioSource;


    private void Awake() 
    {
        _instanceST = this;
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
