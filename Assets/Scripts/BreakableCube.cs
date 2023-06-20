using UnityEngine;
using System.Collections;

public class BreakableCube : MonoBehaviour
{
    private GameObject _fullCube;
    private GameObject _partOfCube;

    [SerializeField] private float _timeToDespawn = 2;

    void Start()
    {
        _fullCube = transform.GetChild(0).gameObject;
        _partOfCube = transform.GetChild(1).gameObject;
        _partOfCube.SetActive(false);
    }


    public void Break()
    {
        Debug.Log("break");
        _fullCube.SetActive(false);
        _partOfCube.SetActive(true);
        StartCoroutine(WaitForCubeDespawn());
    }

    IEnumerator WaitForCubeDespawn()
    {
         yield return new WaitForSeconds(_timeToDespawn);
         Destroy(gameObject);
    }
}
