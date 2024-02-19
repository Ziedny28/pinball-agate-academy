using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    [SerializeField] private float _multiplier = 3f;
    [SerializeField] private float _score;

    [SerializeField] private Color _color;
    [SerializeField] private Collider _bola;
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private VFXManager _vfxManager;
    [SerializeField] private ScoreManager _scoreManager;

    private Animator _animator;
    private Renderer _renderer;

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
            _audioManager.PlaySFX(collision.transform.position);
            _vfxManager.PlayVFX(collision.transform.position);
            _scoreManager.AddScore(_score);
        }    
    }
}
