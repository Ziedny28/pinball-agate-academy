using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallVelocityController : MonoBehaviour
{
    [SerializeField] private float _maxSpeed;

    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(_rb.velocity.magnitude > _maxSpeed)
        {
            _rb.velocity = _rb.velocity.normalized * _maxSpeed;
        }
    }
}
