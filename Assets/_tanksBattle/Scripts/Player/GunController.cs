using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private Transform _gunY;
    [SerializeField] private Transform _gunX;
    [SerializeField] private float _maxXRotation;
    [SerializeField] private float _minXRotation;
    [SerializeField] private float _speedXToRotate;
    [SerializeField] private float _maxYRotation;
    [SerializeField] private float _minYRotation;
    [SerializeField] private float _speedYToRotate;

    private SetWeaponStats _weapon;


    private const float _sensivityCoeff = 0.05f;

    private float _xDegreesToRotate = 0;
    private float _yDegreesToRotate = 0;


    private bool _manageToMove = true;



    public Vector2 ReturnAngleOfGun()
    {
        return new Vector2(_xDegreesToRotate, _yDegreesToRotate);
    }


    private void Start()
    {
        _weapon = GetComponent<SetWeaponStats>();
    }
    private void Update()
    {
        if (_manageToMove == true && _weapon.IsActive == true)
        {
            CheckTouches();
        }
    }
    private void FixedUpdate()
    {
        RotateGun();
    }


    private void CheckTouches()
    {
        if (Input.touches.Length > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                _yDegreesToRotate = _yDegreesToRotate + (touch.deltaPosition.x * _sensivityCoeff);
                _xDegreesToRotate = _xDegreesToRotate + (touch.deltaPosition.y * _sensivityCoeff);
            }
        }
    }

    private void RotateGun()
    {
        ClampRotation();

        if (_gunX != null)
        {
            _gunY.localRotation = Quaternion.RotateTowards(_gunY.localRotation, Quaternion.Euler(_gunY.localRotation.x, _yDegreesToRotate, _gunY.localRotation.z), Time.deltaTime * _speedYToRotate);
            _gunX.localRotation = Quaternion.RotateTowards(_gunX.localRotation, Quaternion.Euler(_xDegreesToRotate, _gunX.localRotation.y, _gunX.localRotation.z), Time.deltaTime * _speedYToRotate);
        }
        else
        {
            _gunY.localRotation = Quaternion.RotateTowards(_gunY.localRotation, Quaternion.Euler(_xDegreesToRotate, _yDegreesToRotate, _gunY.localRotation.z), Time.deltaTime * _speedYToRotate);
        }
        
    }
    private void ClampRotation()
    {
        _yDegreesToRotate = Mathf.Clamp(_yDegreesToRotate, _minYRotation, _maxYRotation);
        _xDegreesToRotate = Mathf.Clamp(_xDegreesToRotate, _minXRotation, _maxXRotation);
    }
}
