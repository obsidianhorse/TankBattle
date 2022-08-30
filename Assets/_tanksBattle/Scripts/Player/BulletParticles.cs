using UnityEngine;

public class BulletParticles : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosion;




    public void PlayExplosion()
    {
        _explosion.Play();
    }
}
