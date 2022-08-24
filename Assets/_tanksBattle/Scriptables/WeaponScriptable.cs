using UnityEngine;


[CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObjects/WeaponData", order = 1)]
public class WeaponScriptable : ScriptableObject
{
    public GameObject _bulletPrefab;
    [Range(0, 100)] public float accuracyPercantage;
    public float _damage;
    public float _shootForce;
    public float _explosionRadius;
    public float _lowReloadTime;
    public float _bigReloadTime;
    public int countOfAmmo;

}
