using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [Range(1.0f,15.0f)]
    [SerializeField] private float _ping;

    private Vector3 _targetPos;

    void FixedUpdate()
    {
        this._targetPos = this.UpdateTargetPosition();

        this.transform.position = Vector3.Lerp(this.transform.position, this._targetPos, this._ping/100);
    }

    private Vector3 UpdateTargetPosition()
    {
        Vector3 newPosition =this._target.position;
        newPosition.z = -10.0f;
        return newPosition;
    }
} 
