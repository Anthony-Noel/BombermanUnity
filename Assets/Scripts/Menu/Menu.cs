using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public bool _alive = true;

    [SerializeField] private Canvas _canvas;
    [SerializeField] private AudioClip _audioClip;


    public void Playgame()
    {
        Time.timeScale = 1;
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
        SceneManager.LoadScene("Menu");
    }

    public void Resum()
    {
        Time.timeScale = 1;
        _canvas.gameObject.SetActive(false);
    }

    private void Update() 
    {
        if (_alive == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if( Time.timeScale == 1)
                {
                    AudioManager._instance.PlaySFX(_audioClip);
                    Time.timeScale = 0;
                    _canvas.gameObject.SetActive(true);
                }
                else
                {
                    AudioManager._instance.PlaySFX(_audioClip);
                    Time.timeScale = 1;
                    _canvas.gameObject.SetActive(false);
                }
            }
        }
    }
}
