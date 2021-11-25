using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [Range(0.1f,10.0f)]
    [SerializeField] private float _ping;

    private Vector3 _targetPos;

    void FixedUpdate()
    {
        this._targetPos = this._target.position;
        if (this._targetPos.x < -0.25f) this._targetPos.x = -0.25f;
        if (this._targetPos.x > 0.25f) this._targetPos.x = 0.25f;
        if (_targetPos.y < -6.25f) this._targetPos.y = -5.25f;
        if (this._targetPos.y > 6.25f) this._targetPos.y = 6.25f;

        this._targetPos.z = -10.0f;

        this.transform.position = Vector3.Lerp(this.transform.position, this._targetPos, this._ping/100);
    }
}
