using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerGameOver : MonoBehaviour
{
    [SerializeField] private Collider _ball;
    [SerializeField] private GameOverUIController _gameOverUIController;

    private void OnTriggerEnter(Collider other)
    {
        if (other == _ball)
        {
            _gameOverUIController.gameObject.SetActive(true);
        }
    }
}
