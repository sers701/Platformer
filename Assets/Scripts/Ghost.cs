using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Ghost : MonoBehaviour
{
    [SerializeField] private Vector3[] _waypoints;
    [SerializeField] private float _pathTime;

    private float _previousHorizontalPosition;
    private SpriteRenderer _spriteRenderer;
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _previousHorizontalPosition = transform.position.x;

        Tween tween = transform.DOPath(_waypoints, _pathTime, PathType.Linear).SetOptions(true);
        tween.SetEase(Ease.Linear).SetLoops(-1);
    }

    private void Update()
    {
        TurnSprite();
    }

    private void TurnSprite()
    {
        if (_previousHorizontalPosition < transform.position.x)
        {
            _spriteRenderer.flipX = true;
            _previousHorizontalPosition = transform.position.x;
        }
        else if (_previousHorizontalPosition > transform.position.x)
        {
            _spriteRenderer.flipX = false;
            _previousHorizontalPosition = transform.position.x;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<KnightMovment>(out KnightMovment knightMovment))
        {
            Destroy(knightMovment.gameObject);
        }
    }
}
