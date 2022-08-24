using UnityEngine;

public class Explosion : MonoBehaviour
{
    private float _damage;
    private float _minDamage;
    



    public void Explode(float explosionRadius, float damage)
    {
        _damage = damage;
        _minDamage = _damage / 2;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.TryGetComponent(out Damagable damagable))
            {
                print("Damage is " + CalculateDamage(damagable, explosionRadius));
                damagable.GetDamage(CalculateDamage(damagable, explosionRadius));
            }
        }
    }
    private float CalculateDamage(Damagable damagable, float radius)
    {
        float calculatedDamage = 0;
        float distance = Vector3.Distance(damagable.transform.position, transform.position);
        float percent = Mathf.InverseLerp(radius, 0, distance);
        calculatedDamage = _minDamage + _minDamage * percent;
        if (Vector3.Distance(damagable.transform.position, transform.position) >= radius)
        {
            return _minDamage;
        }
        else
        {
            return calculatedDamage;
        }
    }
}
