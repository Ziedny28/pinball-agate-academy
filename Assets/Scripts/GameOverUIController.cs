using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUIController : MonoBehaviour
{
    [SerializeField] private Button _mainMenuButton;

    // Start is called before the first frame update
    void Start()
    {
        _mainMenuButton.onClick.AddListener(MainMenu);   
        gameObject.SetActive(false);
    }

   private void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
