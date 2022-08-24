using UnityEngine;
using Cinemachine;


public class SetWeaponStats : MonoBehaviour
{
    [SerializeField] private WeaponScriptable _weaponData;
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;


    private ShootController _shootController;
    private bool _isActive = false;



    public bool IsActive
    {
        get { return _isActive; }
    }

    public void SetActivity(bool isActive)
    {
        _isActive = isActive;
        EnableCamera(_isActive);
    }
    private void EnableCamera(bool isEnable)
    {
        _virtualCamera.gameObject.SetActive(isEnable);
    }




    private void Start()
    {
        _shootController = GetComponent<ShootController>();
        SetShootController();
    }
    private void SetShootController()
    {
        _shootController.SetStats(_weaponData._shootForce, _weaponData.accuracyPercantage, _weaponData._damage, _weaponData.countOfAmmo, _weaponData._lowReloadTime, _weaponData._explosionRadius);
    }
}
