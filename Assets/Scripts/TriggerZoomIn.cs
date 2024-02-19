using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoomIn : MonoBehaviour
{
    [SerializeField] private Collider _bola;
    [SerializeField] private CameraController _cameraController;
    [SerializeField] private float _length;

    private void OnTriggerEnter(Collider other)
    {
        if (other == _bola)
        {
            _cameraController.FollowTarget(_bola.transform, _length);
        }
    }
}
