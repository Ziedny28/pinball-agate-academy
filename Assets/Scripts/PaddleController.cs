using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] private KeyCode _input;

    private float _targetPressed;
    private float _targetReleased;

    private HingeJoint _hinge;

    // Start is called before the first frame update
    void Start()
    {
        _hinge = GetComponent<HingeJoint>();
        _targetPressed = _hinge.limits.max;
        _targetReleased= _hinge.limits.min;
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
    }

    private void ReadInput()
    {
        // langsung menggunakan variabel yang sudah dibuat saat Start
        JointSpring jointSpring = _hinge.spring;

        // mengubah value spring saat input ditekan dan dilepas
        if (Input.GetKey(_input))
        {
            jointSpring.targetPosition = _targetPressed;
        }
        else
        {
            jointSpring.targetPosition = _targetReleased;
        }

        // disni pun langsung menggunakan variabel
        _hinge.spring = jointSpring;
    }
}