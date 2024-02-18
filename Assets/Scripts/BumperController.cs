using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    [SerializeField] private Collider _bola;
    [SerializeField] private float _multiplier = 3f;
    [SerializeField] private Color _color;

    [SerializeField] private Renderer _renderer;
    [SerializeField] private Animator _animator;

    private void Start()
    {
        _animator= GetComponent<Animator>();
        _renderer= GetComponent<Renderer>();

        _renderer.material.color = _color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider == _bola)
        {
            Rigidbody bolaRig = _bola.GetComponent<Rigidbody>();
            bolaRig.velocity *= _multiplier;

            _animator.SetTrigger("hit");
        }    
    }
}