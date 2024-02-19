using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private float _score;

    public float Score
    {
        get { return _score; }
    }

    private void Start()
    {
        ResetScore();
    }

    public void AddScore(float addition)
    {
        _score+= addition;
    }

    public void ResetScore() 
    {
        _score= 0;
    }
}
