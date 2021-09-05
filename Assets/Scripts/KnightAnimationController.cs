using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    public void SwitchCharacterMoving(float horizontalDirection)
    {
        if (horizontalDirection > 0)
        {
            _spriteRenderer.flipX = false;
            _animator.SetBool("IsWalking", true);
        }
        else if (horizontalDirection < 0)
        {
            _spriteRenderer.flipX = true;
            _animator.SetBool("IsWalking", true);
        }
        else
        {
            _animator.SetBool("IsWalking", false);
        }
    }

    public void CoinCollected()
    {
        _animator.SetTrigger("CoinCollected");
    }
}
