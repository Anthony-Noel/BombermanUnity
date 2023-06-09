using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

[ExecuteInEditMode]
public class Exposion : MonoBehaviour
{

    public float _timeDuration = 2;

    public Vector4 _distance = Vector4.one;

    private float _explositionTimeLeft = 0;

    public VisualEffect _explosionVisualEffect;

    public AnimationCurve _distanceAniamtionCurve = AnimationCurve.Constant(0, 1, 1);

    public float _particleFireRateMaximum = 5000;


    [SerializeField, Button("Explode", null, Button.DisplayIn.PlayAndEditModes)] private bool ExplodeButton = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void Explode()
    {
        _explositionTimeLeft = _timeDuration;
    }

    private void UpdateExplosion()
    {
        if (_explosionVisualEffect == null)
            return;

        if (_explositionTimeLeft <= 0)
        {

            _explosionVisualEffect.SetVector4("Distance", Vector4.zero);
            _explosionVisualEffect.SetFloat("firerate", 0);

            return;
        }

        float time = 1 - _explositionTimeLeft / _timeDuration;
        float factor = _distanceAniamtionCurve.Evaluate(time);

        _explosionVisualEffect.SetVector4("Distance", _distance * factor);
        _explosionVisualEffect.SetFloat("firerate", _particleFireRateMaximum);

        _explositionTimeLeft -= Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateExplosion();
    }


}
