using UnityEngine;
using DG.Tweening;


public class Bullet : MonoBehaviour
{
    [SerializeField] private Explosion _explosion;
    [SerializeField] BulletParticles _bulletParticles;
    private Rigidbody _rigidbody;


    private float _damage;
    private float _explosionRadius;



    public void MoveBullet(float force, float accuracy, float damage, float explosionRadius)
    {
        Vector3 pushVector = new Vector3((Random.onUnitSphere.x * 0.1f) * (100 - accuracy) / 100, (Random.onUnitSphere.y * 0.1f) * (100 - accuracy) / 100, -1);
        _rigidbody.AddRelativeForce(pushVector * force);
        _damage = damage;
        _explosionRadius = explosionRadius;
    }
    private void OnCollisionEnter(Collision collision)
    {
        _bulletParticles.PlayExplosion();
        GetComponent<CapsuleCollider>().enabled = false;


        Explosion explosion = Instantiate(_explosion);
        explosion.transform.position = transform.position;
        explosion.Explode(_explosionRadius, _damage);
    }
    private void Awake()
    {
        GetComponents();
    }
    private void GetComponents()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }



    private void Update()
    {
        RotateBullet();
    }
    private void RotateBullet()
    {
        transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
    }
}
