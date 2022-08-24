using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sdf : MonoBehaviour
{
    [SerializeField] private Transform _centerOfMass;


    private Rigidbody _rigidbody;



    private void Start()
    {
        Time.timeScale = 0.2f;
        GetComponents();
    }
    private void GetComponents()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _rigidbody.centerOfMass = _centerOfMass.position;
        _rigidbody.WakeUp();
    }
}
