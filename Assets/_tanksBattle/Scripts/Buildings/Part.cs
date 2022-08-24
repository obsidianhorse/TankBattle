using UnityEngine;
using System.Collections;


public class Part : MonoBehaviour
{
    private Damagable _damagable;
    private Rigidbody _rigidbody;

    private bool _isDestroyed = false;
    private float _forceIndex = 500;



    private void Awake()
    {
        _damagable = GetComponent<Damagable>();
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        _damagable.DeadWithDamage += Destruct;
    }



    private void Destruct(float damage)
    {
        transform.localScale *= 0.95f;
        _rigidbody.isKinematic = false;
        _rigidbody.AddForce(Random.insideUnitSphere * (_forceIndex  + damage * 10));
        _isDestroyed = true;
        StartCoroutine(Disapearing());
    }
    
    private IEnumerator Disapearing()
    {
        yield return new WaitForSeconds(10);

        while (transform.localScale.x >= 0.1f)
        {
            yield return new WaitForSeconds(0.1f);
            transform.localScale *= 0.99f;
        }

        gameObject.SetActive(false);
    }

}
