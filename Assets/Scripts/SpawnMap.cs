using UnityEngine;
using System.Collections.Generic;


public class SpawnMap : MonoBehaviour
{
    [SerializeField] private GameObject _cube;
    [SerializeField] private GameObject _breakableCube;
    [SerializeField] private GameObject _standardFloor;
    [SerializeField] private GameObject _bonusCubeD;
    [SerializeField] private GameObject _bonusCubeM;
    [SerializeField] private int _size;
    [SerializeField] private float _nbOfBreakableCube = 2.5f;
    [SerializeField] private float _nbOfBonusCube;
    [SerializeField] private GameObject[] _groundCubes;
    [SerializeField] private GameObject[] _breakingCubes;
    [SerializeField] private GameObject[] _bonusDistance;
    [SerializeField] private GameObject[] _bonusMoreExplosion;

    private float _entreCubes = 3;
    private int i;

    private CubeState[,] _mapData;

    enum CubeState
    {
        Empty,
        BreakableCube,
        UnbreakableCube,
        BonusCube
    }


    private void Start()
    {
        _mapData = new CubeState[_size, _size];
        // CreateGround();
        CreateStandardFloor();
        CreateUnbreakable();
        CreateBreakable();
        CreateBonusD();
        CreateBonusM();
    }


    void CreateStandardFloor()
    {
        Vector3 position = new Vector3(25, 0, 25);
        GameObject _Floor = Instantiate(_standardFloor, position, Quaternion.identity);
        _Floor.transform.parent = transform;
    }


    void CreateGround()
    {
        _groundCubes = new GameObject[_size * _size];
        
        for (int x = 0; x < _size; x++)
        {
            for (int z = 0; z < _size; z++)
            {                
                    Vector3 position = new Vector3(x * _entreCubes, 0, z * _entreCubes);
                    GameObject _ground = Instantiate(_cube, position, Quaternion.identity);
                    _groundCubes[i++] = _ground;
                    _ground.transform.parent = transform;
            }
        }

        for (int j = 0; j <_size * _size / 2; j++)
        {
            int randomNumber = Random.Range(0, _size * _size);
            GameObject objectToDestroy = _groundCubes[randomNumber];
            GameObject _groundBreakable = Instantiate(_breakableCube, objectToDestroy.transform.position, Quaternion.identity);
            _groundBreakable.transform.parent = transform;
            Destroy(objectToDestroy);
        }
    }


    void CreateUnbreakable()
    {
        for (int x = 0; x < _size - 2; x += 2)
        {
            for (int z = 0; z < _size - 2; z += 2)
            {
                if(_mapData[x,z] == CubeState.Empty)
                {
                    Vector3 position = new Vector3(x * _entreCubes, 0, z * _entreCubes);
                    GameObject _unbreakable = Instantiate(_cube, position, Quaternion.identity);
                    _unbreakable.transform.parent = transform;
                    _mapData[x,z] = CubeState.UnbreakableCube;
                }
            }
        }

        int _centerStartOutline = 1;
        int _centerEndOutline = _centerStartOutline + _size - 2;

        for (int x = 0; x < _size; x++)
        {
            for (int z = 0; z < _size; z++)
            {
                if (x < _centerStartOutline || x >= _centerEndOutline || z < _centerStartOutline || z >= _centerEndOutline)
                {

                        GameObject _unbreakable = Instantiate(_cube, new Vector3(x * _entreCubes, 0, z * _entreCubes), Quaternion.identity);
                        _unbreakable.transform.parent = transform;
                        Transform _transformUnbreakable = _unbreakable.transform;
                }
            }
        }
    }


    void CreateBreakable()
    {
        int _startZone1Start = 1;
        int _startZone1End = _startZone1Start + 2;

        int _startZone2Start = _size -3;
        int _startZone2End = _startZone2Start + 2;

        int w = 0;

        _breakingCubes = new GameObject[_size * _size];

        for (int x = 1; x < _size - 1; x++)
        {
            for (int z = 1; z < _size - 1; z++)
            {
                if (x < _startZone1Start || x >= _startZone1End || z < _startZone1Start || z >= _startZone1End)
                {
                    if (x < _startZone2Start || x >= _startZone2End || z < _startZone2Start || z >= _startZone2End)
                    {
                        if(_mapData[x,z] == CubeState.Empty)
                        {
                            Vector3 position = new Vector3(x * _entreCubes, 0, z * _entreCubes);
                            GameObject _breakable = Instantiate(_breakableCube, position, Quaternion.identity);
                            _breakingCubes[w++] = _breakable;
                            _breakable.transform.parent = transform;
                            Transform _transformBreakable = _breakable.transform;
                            _mapData[x,z] = CubeState.BreakableCube;
                        }
                    }
                }
            }
        }

        for (int j = 0; j <_size * _size / _nbOfBreakableCube; j++)
        {
            int _randomNumber = Random.Range(0, _size * _size - 1);
            GameObject _objectToDestroy = _breakingCubes[_randomNumber];
            Destroy(_objectToDestroy);
        }
    }


    void CreateBonusD()
    {
        _bonusDistance = new GameObject[_size * _size];

        int w = 0;

        for (int x = 1; x < _size - 1; x++)
        {
            for (int z = 1; z < _size - 1; z++)
            {
                        if(_mapData[x,z] == CubeState.BreakableCube)
                        {
                            Vector3 position = new Vector3(x * _entreCubes, 1.5f, z * _entreCubes);
                            GameObject _bonusD = Instantiate(_bonusCubeD, position, Quaternion.identity);
                            _bonusDistance[w++] = _bonusD;
                            _bonusD.transform.parent = transform;
                            // _mapData[x,z] = CubeState.BonusCube;
                        }
            }
        }

        List<GameObject> _list = new List<GameObject>(_bonusDistance);

        for (int j = 0; j < _nbOfBonusCube; j++)
        {
            int _randomNumber = Random.Range(0, _list.Count);
            GameObject _objectToDestroy = _list[_randomNumber];
            Destroy(_objectToDestroy);
            _list.RemoveAt(_randomNumber);
        }
    }

    void CreateBonusM()
    {
        _bonusMoreExplosion = new GameObject[_size * _size];

        int w = 0;

        for (int x = 1; x < _size - 1; x++)
        {
            for (int z = 1; z < _size - 1; z++)
            {
                        if(_mapData[x,z] == CubeState.BreakableCube)
                        {
                            Vector3 position = new Vector3(x * _entreCubes, 1.5f, z * _entreCubes);
                            GameObject _bonusM = Instantiate(_bonusCubeM, position, Quaternion.identity);
                            _bonusMoreExplosion[w++] = _bonusM;
                            _bonusM.transform.parent = transform;
                            // _mapData[x,z] = CubeState.BonusCube;
                        }
            }
        }

        List<GameObject> _list = new List<GameObject>(_bonusMoreExplosion);

        for (int j = 0; j < _nbOfBonusCube; j++)
        {
            int _randomNumber = Random.Range(0, _list.Count);
            GameObject _objectToDestroy = _list[_randomNumber];
            Destroy(_objectToDestroy);
            _list.RemoveAt(_randomNumber);
        }
    }
}