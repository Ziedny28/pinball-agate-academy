using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    [SerializeField] private Collider _bola;
    [SerializeField] private Material _offMaterial;
    [SerializeField] private Material _onMaterial;

    private bool _isOn;
    private Renderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        SetSwitch(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == _bola)
        {
            SetSwitch(!_isOn);
        }
    }

    private void SetSwitch(bool active)
    {
        _isOn = active;
        _renderer.material = active? _onMaterial: _offMaterial;
    }
}
