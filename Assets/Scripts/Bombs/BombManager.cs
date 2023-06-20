using UnityEngine;

public class BombManager : MonoBehaviour
{
    
    public float _timeDuration = 2;
    public Vector4 _distance = Vector4.one;
    public AnimationCurve _distanceAniamtionCurve = AnimationCurve.Constant(0, 1, 1);
    public float _particleFireRateMaximum = 5000;
    public float _radius = 0.5f;
    public int _maxDistance = 3;
    public int _maxBomb = 1;


        public void OnBonusDistance()
    {
        _distance.x += 3;
        _distance.y += 3;
        _distance.z += 3;
        _distance.w += 3;

        _maxDistance +=3;
    }
}
