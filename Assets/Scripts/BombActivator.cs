using UnityEngine;
using UnityEngine.InputSystem;



public class BombActivator : MonoBehaviour
{
    private InputAction _action;
    private PlayerInput _playerInput;
    private Explosion _explosion;
    private Transform _playerTransform;
    private Vector3 _position;
    private Quaternion _rotation;
    private GameObject _bombInstantiate;
    private BombManager _bombManager;
    public int _bombCounter = 0;

    [SerializeField] private GameObject _bomb;


    void Start()
    {
        _bombManager = FindObjectOfType<BombManager>();
        _playerTransform = GetComponent<Transform>();
        _playerInput = GetComponent<PlayerInput>();
        _action = _playerInput.actions.FindAction("Explosion");  
        _action.started += OnAction;
    }

    void OnAction(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (_bombCounter < _bombManager._maxBomb)
            {
                _bombCounter++;
                GameObject _instanceBomb = Instantiate(_bomb, _position, Quaternion.identity);
                _explosion = _instanceBomb.GetComponentInChildren<Explosion>();
                _bombInstantiate = _instanceBomb.GetComponent<GameObject>();
                _explosion.Explode();
            }
        }
    }

    private void Update() 
    {
        _position = _playerTransform.position;
        _position += new Vector3(0, 5, 0);
        _rotation = _playerTransform.rotation;
    }
}