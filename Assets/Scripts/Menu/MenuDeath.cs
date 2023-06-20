using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuDeath : MonoBehaviour
{
    [SerializeField] private Menu _menu;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private AudioClip _audioClip;


    public void Playgame()
    {
        Time.timeScale = 1;
        _canvas.gameObject.SetActive(false);
        SceneManager.LoadScene("Game");
    }

    public void Quitgame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void MenuButton()
    {
        Time.timeScale = 1;
        _canvas.gameObject.SetActive(false);
        SceneManager.LoadScene("Menu");
        _menu._alive = true;
    }

    public void OnDeath() 
    {
        _menu._alive = false;
        SoundTrackManager._instanceST.StopSFX(_audioClip);
        SoundTrackManager._instanceST.PlaySFX(_audioClip);
        Debug.Log("dead");
        Time.timeScale = 0;
        _canvas.gameObject.SetActive(true);
    }
}
