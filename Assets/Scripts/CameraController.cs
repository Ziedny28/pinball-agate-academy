using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _returnTime = 1;
    [SerializeField] private float _followSpeed = 1;
    [SerializeField] private float _length = 5;
    private Vector3 _defaultPosition;
    [SerializeField] private Transform _target;
    public bool HasTarget { get { return _target != null;  } }

    // Start is called before the first frame update
    void Start()
    {
        _defaultPosition = transform.position;
        _target = null;
    }

    private void Update()
    {
        if (HasTarget)
        {
            //kalkulasi posisi u/ fokus ke target
            Vector3 targetToCameraDirection = transform.rotation * -Vector3.forward;
            Vector3 targetPosition = _target.position + (targetToCameraDirection * _length);
            transform.position = Vector3.Lerp(transform.position, targetPosition, _followSpeed * Time.deltaTime);
        }
       
    }

    public void FollowTarget(Transform targetTransform, float length)
    {
        StopAllCoroutines();
        _target = targetTransform;
        _length = length;
    }

    public void GoBackToDefault()
    {
        _target = null; 

        //gerakkan ke posisi default dalam waktu return time
        StopAllCoroutines();
        StartCoroutine(MoveToPosition(_defaultPosition, _returnTime));
    }

    private IEnumerator MoveToPosition(Vector3 target, float time)
    {
        float timer = 0;
        Vector3 start = transform.position;

        while (timer < time)
        {
            //pindahkan kamera secara bertahap
            transform.position = Vector3.Lerp(start, target, Mathf.SmoothStep(0,1,timer/time));

            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        transform.position = target;
    }
}
