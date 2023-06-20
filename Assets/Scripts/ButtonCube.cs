using UnityEngine;
using System.Collections;

public class ButtonCube : MonoBehaviour
{
    private GameObject _fullCube;
    private GameObject _partOfCube;

    void Start()
    {
        _fullCube = transform.GetChild(0).gameObject;
        _partOfCube = transform.GetChild(1).gameObject;
        _partOfCube.SetActive(false);
    }


    public void Break()
    {
        _fullCube.SetActive(false);
        _partOfCube.SetActive(true);
        StartCoroutine(WaitForCubeDespawn());
    }

    IEnumerator WaitForCubeDespawn()
    {
         yield return new WaitForSeconds(5f);
         Destroy(gameObject);
    }
}
