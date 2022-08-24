using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using TMPro;


public class PlaneViewChanger : MonoBehaviour
{
    [SerializeField] private Button _planeViewButton;
    [SerializeField] private CinemachineVirtualCamera _planeCamera;


    private bool _isOnPlane = false;


    private void Start()
    {
        _planeViewButton.onClick.AddListener(OnButtonPressed);
    }
    private void OnButtonPressed()
    {
        _isOnPlane = !_isOnPlane;

        TextMeshProUGUI text = _planeViewButton.GetComponentInChildren<TextMeshProUGUI>();


        if (_isOnPlane == true)
        {
            _planeCamera.gameObject.SetActive(true);
            text.text = "W";
        }
        else
        {
            _planeCamera.gameObject.SetActive(false);
            text.text = "P";
        }
    }
}
