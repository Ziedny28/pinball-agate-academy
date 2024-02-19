using System.Collections;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    private enum SwitchState
    {
        Off,
        On,
        Blink
    }

    [SerializeField] private float _score;

    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private Collider _bola;
    [SerializeField] private Material _offMaterial;
    [SerializeField] private Material _onMaterial;

    private SwitchState _state;
    private Renderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        SetSwitch(false);

        StartCoroutine(BlinkTimerStart(5));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == _bola)
        {
            Toggle();
        }
    }

    private void SetSwitch(bool active)
    {
        if (active)
        {
            _state = SwitchState.On;
            StopAllCoroutines();
        }
        else
        {
            _state = SwitchState.Off;
            StartCoroutine(BlinkTimerStart(5));
        }
        _renderer.material = active? _onMaterial: _offMaterial;
    }

    private void Toggle()
    {
        if(_state == SwitchState.On)
        {
            SetSwitch(false);
        }
        else
        {
            SetSwitch(true);
        }
        _scoreManager.AddScore(_score);
    }

    private IEnumerator Blink(int times)
    {
        _state = SwitchState.Blink;

        for (int i = 0; i < times; i++)
        {
            _renderer.material = _onMaterial;
            yield return new WaitForSeconds(0.5f);
            _renderer.material = _offMaterial;
            yield return new WaitForSeconds(0.5f);
        }

        _state = SwitchState.Off;

        StartCoroutine(BlinkTimerStart(5));
    }

    private IEnumerator BlinkTimerStart(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }
}
