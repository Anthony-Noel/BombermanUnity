using UnityEngine;

public class BonusMoreBombs : MonoBehaviour
{
    private BombManager _bombManager;

    [SerializeField] private AudioClip _audioClip;
    void Start() 
    {
        _bombManager = FindObjectOfType<BombManager>();
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            AudioManager._instance.PlaySFX(_audioClip);
            _bombManager._maxBomb++;
            Destroy(gameObject);
        }
    }
}
