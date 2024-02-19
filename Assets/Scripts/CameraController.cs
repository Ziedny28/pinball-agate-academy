using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _dummyTarget;
    [SerializeField] private float _dummyLength = 6;

    private Vector3 _defaultPosition;
    private Transform _target;

    // Start is called before the first frame update
    void Start()
    {
        _defaultPosition = transform.position;
        _target = null;
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            FocusAtTarget(_dummyTarget,_dummyLength);
        }
        if (Input.GetKey(KeyCode.R))
        {
            GoBackToDefault();
        }
    }

    private void FocusAtTarget(Transform targetTransform, float length)
    {
        _target = targetTransform;

        //kalkulasi posisi u/ fokus ke target
        Vector3 targetToCameraDirection = transform.rotation * -Vector3.forward;
        Vector3 targetPosition = targetTransform.position + (targetToCameraDirection *length);

        //gerakan ke posisi tersebut
        StartCoroutine(MoveToPosition(targetPosition, 5));
    }

    private void GoBackToDefault()
    {
        _target = null; 
        StartCoroutine(MoveToPosition(_defaultPosition, 5));
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
