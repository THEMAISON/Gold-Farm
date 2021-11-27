using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(1,10)]
    [SerializeField] private int _speedMove;
    private Rigidbody2D _rb;

    private bool _isMoving = true;

    public bool IsMoving
    {
        get { return this._isMoving; }
        set { this._isMoving = value; }

    }

    void Start()
    {
        this._rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (this._isMoving == true)
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            Vector2 dir = new Vector2(moveX * this._speedMove, moveY * this._speedMove);
            if (dir.magnitude > 1) dir = dir.normalized * this._speedMove;

            this._rb.velocity = dir;
        }
        else this._rb.velocity = Vector2.zero;
    }
}
