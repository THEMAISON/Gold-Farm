using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(1,10)]
    [SerializeField] private int _speedMove;
    private Rigidbody2D rb;

    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 dir = new Vector2(moveX*_speedMove, moveY*this._speedMove);
        if (dir.magnitude > 1) dir = dir.normalized * this._speedMove;
        
        rb.velocity = dir;
    }
}
