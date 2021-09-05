using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GroundChecker))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(KnightAnimationController))]

public class KnightMovment : MonoBehaviour
{
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _jumpHeight;
    
    private Vector2 _jumpVelocity;
    private Rigidbody2D _rigidbody2D;
    private GroundChecker _groundChecker;
    private KnightAnimationController _knightAnimationController;
    private void Awake()
    {
        _jumpVelocity = Mathf.Sqrt(2 * _jumpHeight * Physics.gravity.magnitude) * Vector2.up;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _groundChecker = GetComponent<GroundChecker>();
        _knightAnimationController = GetComponent<KnightAnimationController>();
    }

    private void Update()
    {
        if (_groundChecker.IsGrounded() && Input.GetAxis("Vertical") > 0)
        {
            Jump();
        }
        Walk();
    }

    private void Jump()
    {
        _rigidbody2D.velocity = _rigidbody2D.velocity.x * Vector2.right + _jumpVelocity;
    }

    private void Walk()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float horizontalVelocity = _walkSpeed * horizontalInput;
        float verticalVelocity = _rigidbody2D.velocity.y;
        _rigidbody2D.velocity = horizontalVelocity * Vector2.right + verticalVelocity * Vector2.up;
        _knightAnimationController.SwitchCharacterMoving(horizontalVelocity);
    }
}
