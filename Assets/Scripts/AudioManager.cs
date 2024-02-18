using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _bgmSorce;
    // Start is called before the first frame update
    void Start()
    {
        PlayBGM(); 
    }
    
    private void PlayBGM()
    {
        _bgmSorce.Play();
    }

    private void PlaySFX()
    {

    }
}
