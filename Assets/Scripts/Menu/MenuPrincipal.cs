using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class MenuPrincipal : MonoBehaviour
{
    
    public void Playgame()
    {
        StartCoroutine(WaitForPlaygame());
    }

    public void Quitgame()
    {
        StartCoroutine(WaitForQuitgame());
    }

    IEnumerator WaitForPlaygame()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Game");
    }

    IEnumerator WaitForQuitgame()
    {
        yield return new WaitForSeconds(1.5f);
        Debug.Log("QUIT");
        Application.Quit();
    }
}
