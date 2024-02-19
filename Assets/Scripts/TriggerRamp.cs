using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRamp : MonoBehaviour
{
    [SerializeField] private float _score;
    [SerializeField] private Collider _ball;
    [SerializeField] private ScoreManager _scoreManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other == _ball)
        {
            _scoreManager.AddScore(_score);
        }
    }


}
