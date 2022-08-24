using UnityEngine;
using UnityEngine.UI;

public class WeaponChanger : MonoBehaviour
{
    [SerializeField] private SetWeaponStats[] _weapons;
    [SerializeField] private Button[] _moveToWeapons;



    private int _weaponIndex = 0;

    private void Start()
    {
        ChooseWeapon();
       MoveCameraToWeaponListeners();
    }
    private void MoveCameraToWeaponListeners()
    {
        _moveToWeapons[0].onClick.AddListener(MoveCameraToPreviousWeapon);
        _moveToWeapons[1].onClick.AddListener(MoveCameraToNextWeapon);
    }
    private void MoveCameraToPreviousWeapon()
    {
        _weaponIndex--;
        ClampWeaponIndex();
        ChooseWeapon();
    }
    private void MoveCameraToNextWeapon()
    {
        _weaponIndex++;
        ClampWeaponIndex();
        ChooseWeapon();
    }
    private void ClampWeaponIndex()
    {
        _weaponIndex = Mathf.Clamp(_weaponIndex, 0, _weapons.Length);
    }
    private void ChooseWeapon()
    {
        for (int i = 0; i < _weapons.Length; i++)
        {
            if (i == _weaponIndex)
            {
                _weapons[i].SetActivity(true);
            }
            else
            {
                _weapons[i].SetActivity(false);
            }
        }
    }
}
