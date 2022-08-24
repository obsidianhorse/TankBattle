using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    private Damagable _damagable;




    private void Awake()
    {
        _damagable = GetComponent<Damagable>();
        _damagable.Damaged += UpdateHealthUI;
    }
    private void UpdateHealthUI(float health)
    {
        _slider.value = health / 100;
        if (_slider.value <= 0)
        {
            _slider.gameObject.SetActive(false);
        }
    }
}
