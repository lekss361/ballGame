﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpforce;
    [SerializeField] private CheckGround _isGround;
    [SerializeField] private Coin _coin;
    [SerializeField] private GameObject _textCoin;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _isGround = GetComponent<CheckGround>();
        _coin = _textCoin.GetComponent<Coin>();
    }

    void Update()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        _rigidbody.velocity=new Vector2(Horizontal* _speed, _rigidbody.velocity.y);

        if (Input.GetAxisRaw("Vertical")==1)
        {
            if (_isGround._CheckGround())
            {
                _rigidbody.AddForce(Vector2.up * _jumpforce, ForceMode2D.Impulse);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            _coin.AddCoins(1);
            Destroy(collision.gameObject);
        }
    }
}