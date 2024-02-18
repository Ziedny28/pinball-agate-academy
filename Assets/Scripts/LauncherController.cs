using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    [SerializeField] private Collider _bola;
    [SerializeField] private KeyCode _input;
    [SerializeField] private Material _holdMaterial;
    [SerializeField] private Material _initMaterial;

    [SerializeField] private float _maxTimeHold;
    [SerializeField] private float _maxForce;

    private bool isHold = false;
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.material = _initMaterial;
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.collider == _bola)
        {
            ReadInput(_bola);
        }
    }

    private void ReadInput(Collider collider)
    {
        if (Input.GetKey(_input) && !isHold)
        {
            StartCoroutine(StartHold(collider));
        }
    }

    private IEnumerator StartHold(Collider collider)
    {
        isHold = true;
        float force = 0.0f;
        float timeHold = 0.0f;

        _renderer.material = _holdMaterial;

        while (Input.GetKey(_input)) 
        { 
            force = Mathf.Lerp(0,_maxForce, timeHold/_maxTimeHold);

            yield return new WaitForEndOfFrame();
            timeHold += Time.deltaTime;
        }

        _renderer.material = _initMaterial;

        collider.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
        isHold= false;
    }
}
