using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

[ExecuteInEditMode]
public class Explosion : MonoBehaviour
{
    private float _explosionTimeLeft = 0;
    private GameObject _bombInstantiate;
    private GameObject _bombInstantiatePhysic;
    private BombManager _bombManager;
    private BreakableCube _breakableCube;
    private BombActivator _bombActivator;
    private MenuDeath _menuDeath;
    private GameObject _bomberMan;
    private Color color = Color.red;
    private RaycastHit hitObject;

    [SerializeField] private AudioClip _meche;
    [SerializeField] private AudioClip _boom;
    [SerializeField] private VisualEffect _explosionVisualEffect;
    [SerializeField , Button("Explode", null , Button.DisplayIn.PlayAndEditModes)]private bool ExplodeButton = false;


    private void Start() 
    {
        _menuDeath = FindObjectOfType<MenuDeath>();
        _bombManager = FindObjectOfType<BombManager>();
        _bomberMan = GameObject.Find("Bomberman");
        _bombActivator = _bomberMan.GetComponent<BombActivator>();
        _bombInstantiate = transform.parent.gameObject;
        _bombInstantiatePhysic = transform.parent.Find("Bomb").gameObject;
    }

    public void Explode()
    {
        StartCoroutine(WaitForExplode());
    }

    IEnumerator WaitForExplode()
    {
        AudioManager._instance.PlaySFX(_meche);
        yield return new WaitForSeconds(2f);
        AudioManager._instance.StopSFX(_meche);
        AudioManager._instance.PlaySFX(_boom);
        _explosionTimeLeft = _bombManager._timeDuration;
        Vector3 origin = transform.position;
        Vector3[] directions = { transform.forward, transform.right, transform.up, -transform.forward, -transform.right, -transform.up };
        LayerMask _goodLayerMask = LayerMask.GetMask("Breakable");
        LayerMask _badLayerMask = LayerMask.GetMask("Unbreakable");
        LayerMask _playerLayerMask = LayerMask.GetMask("Player");

        foreach (Vector3 direction in directions)
        {
            if (Physics.SphereCast(transform.position, _bombManager._radius, direction, out hitObject, _bombManager._maxDistance, _goodLayerMask))
            {
                GameObject objetTouche = hitObject.collider.gameObject;
                Debug.Log("Objet touché : " + objetTouche.name);
                _breakableCube = objetTouche.GetComponentInParent<BreakableCube>();
                _breakableCube.Break();
            }

            if (Physics.SphereCast(transform.position, _bombManager._radius, direction, out hitObject, _bombManager._maxDistance, _playerLayerMask))
            {
                Debug.Log("you died !");
                _menuDeath.OnDeath();
            }
        }

            if (Physics.SphereCast(transform.position, _bombManager._radius, transform.right, out hitObject, _bombManager._maxDistance, _badLayerMask))
            {
                StartCoroutine(WaitForTrueX());
            }
            if (Physics.SphereCast(transform.position, _bombManager._radius, -transform.right, out hitObject, _bombManager._maxDistance, _badLayerMask))
            {
                StartCoroutine(WaitForTrueY());
            }
            if (Physics.SphereCast(transform.position, _bombManager._radius, transform.forward, out hitObject, _bombManager._maxDistance, _badLayerMask))
            {
                StartCoroutine(WaitForTrueZ());
            }
            if (Physics.SphereCast(transform.position, _bombManager._radius, -transform.forward, out hitObject, _bombManager._maxDistance, _badLayerMask))
            {
                StartCoroutine(WaitForTrueW());
            }

        _bombInstantiatePhysic.SetActive(false);
        _bombActivator._bombCounter--;
        yield return new WaitForSeconds(2.25f);

        Destroy(_bombInstantiate);
    }


    IEnumerator WaitForTrueX()
    {
        float valeurTemporaire = _bombManager._distance.x;
        _bombManager._distance.x = 0;
        yield return new WaitForSeconds(1f);
        _bombManager._distance.x = valeurTemporaire;
    }

    IEnumerator WaitForTrueY()
    {
        float valeurTemporaire = _bombManager._distance.y;
        _bombManager._distance.y = 0;
        yield return new WaitForSeconds(1f);
        _bombManager._distance.y = valeurTemporaire;
    }

        IEnumerator WaitForTrueZ()
    {
        float valeurTemporaire = _bombManager._distance.z;
        _bombManager._distance.z = 0;
        yield return new WaitForSeconds(1f);
        _bombManager._distance.z = valeurTemporaire;
    }

        IEnumerator WaitForTrueW()
    {
        float valeurTemporaire = _bombManager._distance.w;
        _bombManager._distance.w = 0;
        yield return new WaitForSeconds(1f);
        _bombManager._distance.w = valeurTemporaire;
    }


    public void UpdateExplosion()
    {
        if (_explosionVisualEffect == null)
            return;

        if (_explosionTimeLeft <= 0)
        {

            _explosionVisualEffect.SetVector4("Distance", Vector4.zero);
            _explosionVisualEffect.SetFloat("firerate", 0);

            return;
        }

        float time = 1 - _explosionTimeLeft / _bombManager._timeDuration;
        float factor = _bombManager._distanceAniamtionCurve.Evaluate(time);

        _explosionVisualEffect.SetVector4("Distance", _bombManager._distance * factor);
        _explosionVisualEffect.SetFloat("firerate", _bombManager._particleFireRateMaximum);

        _explosionTimeLeft -= Time.deltaTime;
    }


    void Update()
    {
        UpdateExplosion();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawWireSphere(transform.position, _bombManager._radius);
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * _bombManager._maxDistance);
        Gizmos.DrawLine(transform.position, transform.position + transform.right * _bombManager._maxDistance);
        Gizmos.DrawLine(transform.position, transform.position + transform.up * _bombManager._maxDistance);
        Gizmos.DrawLine(transform.position, transform.position + -transform.forward * _bombManager._maxDistance);
        Gizmos.DrawLine(transform.position, transform.position + -transform.right * _bombManager._maxDistance);
        Gizmos.DrawLine(transform.position, transform.position + -transform.up * _bombManager._maxDistance);
    }
}