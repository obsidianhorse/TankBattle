using System;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    private float _health = 100;

    public event Action<float> Damaged;
    public event Action Dead;
    public event Action<float> DeadWithDamage;




    public void GetDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Dead?.Invoke();
            DeadWithDamage?.Invoke(damage);
        }
        Damaged?.Invoke(_health);
    }
}
