using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class CharacterController : MonoBehaviour
{
    #region Self Variables

    #region Serialized Variables

    [SerializeField] private GameObject camera;
    [SerializeField] float speed = 0.0f;
    [SerializeField] private float moveDirection;
    [SerializeField] private float jumpForce;

    #endregion
    
    #region Private Variables
    
    private AudioSource _audioSource;
    private Animator _animator;
    private Rigidbody2D _r2d;
    private SpriteRenderer _spriteRenderer;
    private bool _grounded = true;
    private bool _jump;
    private bool _moving;
    
    #endregion
    #endregion
    
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _r2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_r2d.velocity != Vector2.zero)
        {
            _moving = true;
        }
        else
        {
            _moving = true;
        }
        _r2d.velocity = new Vector2(speed * moveDirection, _r2d.velocity.y);
        if (_jump)
        {
            _r2d.velocity = new Vector2(_r2d.velocity.x, jumpForce);
            _jump = false;
        }
    }

    private void Update()
    {
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection = -1.0f;
                _spriteRenderer.flipX = true;
                _animator.SetFloat("Speed", speed);
            }
            else if(Input.GetKey(KeyCode.D))
            {
                moveDirection = 1.0f;
                _spriteRenderer.flipX = false;
                _animator.SetFloat("Speed", speed);
            }
        }
        else if (_grounded)
        {
            moveDirection = 0.0f;
            _animator.SetFloat("Speed", 0);
        }

        if (_grounded && Input.GetKeyDown(KeyCode.W))
        {
            _jump = true;
            _grounded = false;
            _animator.SetTrigger("Jump");
            _animator.SetBool("Grounded", false);
        }
    }

    private void LateUpdate()
    {
        var position = transform.position;
        camera.transform.position = new Vector3(position.x, position.y, position.z - 1f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _animator.SetBool("Grounded", true);
            _grounded = true;
        }
    }
}
