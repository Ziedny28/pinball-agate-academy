using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _bgmSorce;
    [SerializeField] private GameObject _sfxSource;

    // Start is called before the first frame update
    void Start()
    {
        PlayBGM(); 
    }
    
    private void PlayBGM()
    {
        _bgmSorce.Play();
    }

    public void PlaySFX(Vector3 spawnPosition)
    {
        Instantiate(_sfxSource, spawnPosition, Quaternion.identity);
    }
}
