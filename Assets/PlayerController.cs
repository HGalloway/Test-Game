using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Transform Player;
    public GameObject PlayerObject;
    private Vector3 _originalPosition;

    //Sprint
    public float SprintModifier = 1.5f;

    //Player Falling 
    // private bool _hasPlayerFallen = false;
    public Transform PlayerRespawnPoint; 
    
    //Mouse Movement
    private float _mouseX;
    private float _mouseY;

    public float XSensitivity;
    public float YSensitivity;

    public float XMinTurnAngle;
    public float XMaxTurnAngle;

    private float _xRotation;
    private float _yRotation;

    //Player Movement
    public CharacterController CharacterController;

    public float InitialPlayerSpeed;
    private float _playerSpeed;
    public float Gravity;
    public float JumpHeight;

    private bool _isPlayerGrounded;
    private Vector3 _moveDirection = Vector3.zero;

    void Start() {
        _playerSpeed = InitialPlayerSpeed;
        _originalPosition = Player.position;
    }

    // Update is called once per frame
    void Update() {
        Sprint();
        
        HandleMouseMovement();
        HandleKeyboardMovement();
    }

    void HandleMouseMovement() {
        _mouseX = Input.GetAxis("Mouse X") * XSensitivity * Time.deltaTime;
        _mouseY = Input.GetAxis("Mouse Y") * YSensitivity * Time.deltaTime;
        
        _xRotation -= _mouseY;
        _yRotation += _mouseX;

        _xRotation = Mathf.Clamp(_xRotation, XMinTurnAngle, XMaxTurnAngle);

        Player.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
    }

    void HandleKeyboardMovement() {
        _isPlayerGrounded = CharacterController.isGrounded;

        if (_isPlayerGrounded) {
            _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            _moveDirection = transform.TransformDirection(_moveDirection);
            _moveDirection *= _playerSpeed;
            if (Input.GetButton("Jump")){
                _moveDirection.y = JumpHeight;
            }
        }
        _moveDirection.y -= Gravity * Time.deltaTime;
        CharacterController.Move(_moveDirection * Time.deltaTime);
    }

    void Sprint() {
        if (Input.GetKey(KeyCode.LeftShift)) {
            _playerSpeed = _playerSpeed + SprintModifier; 
        }
        else {
            _playerSpeed = InitialPlayerSpeed;
        }
    }
}