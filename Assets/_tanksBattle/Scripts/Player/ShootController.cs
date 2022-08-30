using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class ShootController : MonoBehaviour
{
    [SerializeField] private FireButton _fireButton;
    [SerializeField] private Button _shootButton;
    [SerializeField] private Transform _pointOfFireRoot;
    [SerializeField] private Bullet _bullet;

    private Transform[] _firePoints;
    private int _firePointIndex = 1;

    private bool _shootPaused = false;

    private float _force;
    private float _accuracyPercantage;
    private float _damage;
    private int _ammo;
    private float _shootPause;
    private float _explosionRadius;


    public void SetStats(float force, float accuracyPercantage, float damage, int ammo, float shootPause, float explosionRadius)
    {
        _force = force;
        _accuracyPercantage = accuracyPercantage;
        _damage = damage;
        _ammo = ammo;
        _shootPause = shootPause;
        _explosionRadius = explosionRadius;
    }

    void Start()
    {
        //_shootButton.onClick.AddListener(MoveBullet);
        _fireButton.ButtonSelected += MoveBullet;
        GetAllFirePoints();
    }

   
    private void GetAllFirePoints()
    {
        _firePoints = _pointOfFireRoot.GetComponentsInChildren<Transform>();
    }
    private void MoveBullet()
    {
        if (CheckIsCanShoot() == false)
        {
            return;
        }
            
        Bullet bullet = Instantiate(_bullet, _firePoints[_firePointIndex].position, _pointOfFireRoot.parent.rotation);
        bullet.MoveBullet(_force, _accuracyPercantage, _damage, _explosionRadius);
        _ammo--;
        SetNextFirePoint();
        _shootPaused = true;
        StartCoroutine(PauseShoot());

    }
    private IEnumerator PauseShoot()
    {
        yield return new WaitForSeconds(_shootPause);
        _shootPaused = false;
    }
    private bool CheckIsCanShoot()
    {
        return _ammo > 0 && _shootPaused == false;
    }
    private void SetNextFirePoint()
    {
        _firePointIndex++;
        if (_firePointIndex >= _firePoints.Length)
        {
            _firePointIndex = 1;
        }
    }
}