using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoomOut : MonoBehaviour
{
    [SerializeField] private Collider _bola;
    [SerializeField] private CameraController _cameraController;

    private void OnTriggerEnter(Collider other)
    {
        if (other == _bola)
        {
            _cameraController.GoBackToDefault();
        }
    }
}
