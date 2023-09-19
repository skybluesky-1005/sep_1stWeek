using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public Text playerName;

    private Vector2 _movementDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    public float speed = 0f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        if (PlayerPrefs.HasKey("Name"))
        {
            string _name = PlayerPrefs.GetString("Name");
            playerName.text = _name;
            Debug.Log("PlayerPrefs.GetString(\"Name\"): " + PlayerPrefs.GetString("Name"));
            Debug.Log("playerName.text: " + playerName.text);
            Debug.Log("_name: " + _name);
        }
    }

    private void Start()
    {
        OnMoveEvent += Move;
        _animator.SetBool("isWalk", false);
    }

    private void FixedUpdate()
    {
        ApplyMovment(_movementDirection);

        if (_movementDirection != Vector2.zero)
            _animator.SetBool("isWalk", true);
        else
            _animator.SetBool("isWalk", false);
    }

    private void Move(Vector2 direction)
    {
        _movementDirection = direction;
    }

    private void ApplyMovment(Vector2 direction)
    {
        direction = direction * speed;

        _rigidbody.velocity = direction;
    }

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }

    public void OnLook(InputValue value)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (transform.position.x < mousePos.x)
        {
            Vector3 right = new Vector3(1, 1, 1);
            transform.localScale = right;
        }
        else
        {
            Vector3 left = new Vector3(-1, 1, 1);
            transform.localScale = left;
        }
    }
}
